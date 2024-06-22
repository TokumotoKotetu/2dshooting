using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] bool _playerBullet = true;
    [SerializeField] float _myBulletDestroyTime;
    [SerializeField] float _enemyBulletDestroyTime;
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
    private void obDestroy()
    {
        Destroy(this.gameObject);
    }
}
