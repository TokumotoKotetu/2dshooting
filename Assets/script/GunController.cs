using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunController : MonoBehaviour
{
    /// <summary> 弾丸のプレファブ </summary>
    [SerializeField] GameObject _bulletPrefab;
    /// <summary> 照準 </summary>
    [SerializeField] Transform _firePoint;
    /// <summary> 発射間隔 </summary>
    [SerializeField] float _shotInterval = 1.0f;
    /// <summary> 銃弾の速度 </summary>
    [SerializeField] float _bulletspeed = 20f;
    /// <summary> カメラ </summary>
    [SerializeField] Camera _cam;
    /// <summary> 移動速度 </summary>
    [SerializeField] float _moveSpeed = 1f;
    public AudioClip _gunSound;
    AudioSource _audioSource;
    float _timer;
    Rigidbody2D _rb = default;
    Vector2 _mousePos;
    Vector2 _movement;



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _timer = _shotInterval;
        _cam = Camera.main;
        _audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        _timer += Time.deltaTime;

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && _timer > _shotInterval) 
        {
            _timer = 0;
            Shot();
            _audioSource.PlayOneShot(_gunSound);
        }

        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //移動処理
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        //マウスの方向に向きを合わせる
        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        _rb.rotation = angle;
    }

    void Shot() //弾丸発射処理
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletspeed, ForceMode2D.Impulse);
    }

 
}
