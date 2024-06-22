using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの移動する力
    [SerializeField] public float moveSpeed = 100f;
    Rigidbody2D m_rb = default;
    [SerializeField] Camera cam;
    [SerializeField] GameObject handgun;
    [SerializeField] GameObject crossbow;
    [SerializeField] GameObject player;
    [SerializeField] public int HP = 10;
    GameObject obj;
    [SerializeField] GameObject[] weaponPos;
    [SerializeField] float _flashInterval;
    [SerializeField] int loopCount;
    PolygonCollider2D _polygonCollider2d;
    SpriteRenderer _spriteRenderer;
    public AudioClip _damage;
    AudioSource _audioSource;
    int weaponCounter = 0;   
    Vector2 movement;
    Vector2 mousePos;
    int _haveWeaponNumber = 0;
    bool _isHit;
    PlayerState state;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();    
        _polygonCollider2d = GetComponent<PolygonCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //武器の召喚
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetGun();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetCrossbow();
        }
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
            obj.transform.parent = player.transform;
            weaponCounter++;
            _haveWeaponNumber++;
        }
    }
    private void FixedUpdate()
    {
        //プレイヤーの移動
        m_rb.MovePosition(m_rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHit)
        {
            return;
        }

        if (collision.tag == "Enemy")
        {
            StartCoroutine(_hit());
            HP -= 1;
        }
        

    }

    IEnumerator _hit()
    {
        _isHit = true;
        _audioSource.PlayOneShot(_damage);
        _polygonCollider2d.enabled = false;

        for(int j = 0; j < loopCount; j++)
        {
            yield return new WaitForSeconds(_flashInterval);
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(_flashInterval);
            _spriteRenderer.enabled = true;
        }
        _polygonCollider2d.enabled = true;
        _isHit = false;
    }

    enum PlayerState
    {
        NOMAL,DAMAGED,MUTEKI
    }
}
