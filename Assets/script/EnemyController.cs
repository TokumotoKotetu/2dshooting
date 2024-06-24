using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int HP = 3;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] int _bulletDamage = 1;
    [SerializeField] int _arrowDamage = 2;
    [SerializeField] int _attackInterval;
    [SerializeField] GameObject _shotPrefab;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _shotSpeed;
    [SerializeField] int _minDropExp, _maxDropExp;
    [SerializeField] GameObject _expPrefab;
    Rigidbody2D rb;
    CircleCollider2D _circleCollider2D;
    PlayerScanner _playerScanner;
    GameController _gameController;
    GameObject Target;
    Vector2 _playerPos;
    float timer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerScanner = GetComponent<PlayerScanner>();
        GameObject obj = GameObject.Find("GameController");
        _gameController = obj.GetComponent<GameController>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > _attackInterval)
        {
            timer = 0f;
            Shot();
        }

        if (HP <= 0)
        {
            _gameController._score += 1;
            int _dropExp = Random.Range(_minDropExp, _maxDropExp + 1);
            for(int i = _dropExp; i > 0; i--) 
            {
                float radius = _circleCollider2D.radius;
                var expPos = radius * Random.insideUnitCircle;
                Vector2 myPos = transform.position;
                GameObject exp = Instantiate(_expPrefab,new Vector2(expPos.x + myPos.x ,expPos.y + myPos.y),Quaternion.identity);
            }
            Destroy(gameObject);
        }


        try
        {
            Target = _playerScanner.ScanWithFindTag();
            _playerPos = Target.transform.position;
        }
        catch
        {

        }


    }

    private void FixedUpdate()
    {
        Vector2 lookDir = _playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;

        Vector2 velocity = gameObject.transform.up * _moveSpeed;
        rb.position += velocity * Time.deltaTime;
    }

    void Shot()
    {
        GameObject arrow = Instantiate(_shotPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _shotSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("ƒoƒŒƒbƒg‚ª“–‚½‚Á‚½");
            Destroy(collision.gameObject);
            HP -= _bulletDamage;
        }
        else if(collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
            HP -= _arrowDamage;
        }
    }


}
