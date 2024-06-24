using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    Rigidbody2D _rb;
    PlayerScanner _playerScanner;
    GameObject _target;
    Vector2 _playerPos;
    [SerializeField] float _moveSpeed;
    bool _onHit = false;
    int _onHIts = 0;

    public void Start()
    {
        _playerScanner = GetComponent<PlayerScanner>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        try
        {
            _target = _playerScanner.ScanWithFindTag();
            _playerPos = _target.transform.position;
        }
        catch
        {

        }       
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = _playerPos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        _rb.rotation = angle;

        if (_onHit)
        {
            Vector2 velocity = gameObject.transform.up * _moveSpeed;
            _rb.position += velocity * Time.deltaTime;
        }
    }
    public void ExpRangeHit()
    {
        _onHit = true;
        _onHIts += 1;
    }
}
