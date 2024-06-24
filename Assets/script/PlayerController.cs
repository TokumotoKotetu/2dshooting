using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    CircleCollider2D _circleCollider2d;
    Rigidbody2D m_rb = default;
    AudioSource _audioSource;
    [SerializeField] Camera cam;
    GameObject obj;
    [SerializeField] GameObject handgun;
    [SerializeField] GameObject crossbow;
    [SerializeField] GameObject player;
    [SerializeField] public GameObject[] weaponPos;
    LevelController _levelController;
    [SerializeField] public float moveSpeed = 100f;
    [SerializeField] float _flashInterval;
    [SerializeField] int loopCount;
    public AudioClip _damage;
    int weaponCounter = 0;   
    Vector2 movement;
    Vector2 mousePos;
    public int _haveWeaponNumber = 0;
    bool _isHit;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();    
        _circleCollider2d = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _levelController = GetComponent<LevelController>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void GetGun()
    {
        if (weaponCounter == _haveWeaponNumber && _haveWeaponNumber < weaponPos.Length)
        {
            obj = (GameObject)Instantiate(handgun, weaponPos[_haveWeaponNumber].transform.position, Quaternion.identity);
            obj.transform.parent = player.transform;
            weaponCounter++;
            _haveWeaponNumber++;
        }
    }
    public void GetCrossbow()
    {
        if (weaponCounter == _haveWeaponNumber && _haveWeaponNumber < weaponPos.Length)
        {
            obj = (GameObject)Instantiate(crossbow, weaponPos[_haveWeaponNumber].transform.position, Quaternion.identity);
            obj.transform.parent = this.player.transform;
            weaponCounter++;
            _haveWeaponNumber++;
        }
    }
    private void FixedUpdate()
    {
        //ƒvƒŒƒCƒ„[‚ÌˆÚ“®
        m_rb.MovePosition(m_rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHit)
        {
            return;
        }

        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            StartCoroutine(_hit());
            _levelController.Damage();

            if(collision.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
            }
        }
        

    }

    IEnumerator _hit()
    {
        _isHit = true;
        _audioSource.PlayOneShot(_damage);
        _circleCollider2d.enabled = false;

        for(int j = 0; j < loopCount; j++)
        {
            yield return new WaitForSeconds(_flashInterval);
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(_flashInterval);
            _spriteRenderer.enabled = true;
        }
        _circleCollider2d.enabled = true;
        _isHit = false;
    }

    enum PlayerState
    {
        NOMAL,DAMAGED,MUTEKI
    }
}
