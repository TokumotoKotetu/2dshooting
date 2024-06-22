using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int HP = 3;
    [SerializeField] int _bulletDamage = 1;
    [SerializeField] int _arrowDamage = 2;
    [SerializeField] int _attackInterval;
    [SerializeField] GameObject _shotPrefab;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _shotSpeed;
    Rigidbody2D rb;
    PlayerScanner _playerScanner;
    GameObject Target;
    Vector2 _playerPos;
    float timer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerScanner = GetComponent<PlayerScanner>();
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
