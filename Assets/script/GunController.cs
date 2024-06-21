using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunController : MonoBehaviour
{
    /// <summary> �e�ۂ̃v���t�@�u </summary>
    [SerializeField] GameObject _bulletPrefab;
    /// <summary> �Ə� </summary>
    [SerializeField] Transform _firePoint;
    /// <summary> ���ˊԊu </summary>
    [SerializeField] float _shotInterval = 1.0f;
    /// <summary> �e�e�̑��x </summary>
    [SerializeField] float _bulletspeed = 20f;
    /// <summary> �J���� </summary>
    [SerializeField] Camera _cam;
    /// <summary> �ړ����x </summary>
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
        //�ړ�����
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        //�}�E�X�̕����Ɍ��������킹��
        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        _rb.rotation = angle;
    }

    void Shot() //�e�۔��ˏ���
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletspeed, ForceMode2D.Impulse);
    }

 
}
