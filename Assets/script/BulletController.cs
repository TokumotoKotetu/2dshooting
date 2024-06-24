using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] int _bulletDamage = 1;
    [SerializeField] bool _playerBullet = true;
    [SerializeField] float _myBulletDestroyTime;
    [SerializeField] float _enemyBulletDestroyTime;
    [SerializeField] int _enemyPenetrate = 1;
    int _attackEnemyCount;
    private void Start()
    {
        if (_playerBullet)
        {
            Invoke(nameof(obDestroy), _myBulletDestroyTime);
        }
        else
        {
            Invoke(nameof(obDestroy), _enemyBulletDestroyTime);
        }
        
    }
    private void Update()
    {
        if(_attackEnemyCount >= _enemyPenetrate)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_playerBullet)
        {
            if (collision.tag == "Enemy")
            {
                _attackEnemyCount++;
            }
        }
        else
        {
            if (collision.tag == "Player")
            {
                _attackEnemyCount++;
            }
        }

    }
    private void obDestroy()
    {
        Destroy(this.gameObject);
    }
}
