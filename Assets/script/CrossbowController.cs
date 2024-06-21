using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrossbowController : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _shotInterval = 3f;
    [SerializeField] float _arrowSpeed = 20f;
    [SerializeField] float _moveSpeed = 1f;
    public AudioClip _arrowSound;
    AudioSource _audioSource;
    float timer = 0f;
    Rigidbody2D rb = default;
    Vector2 movement;
    Vector2 enemyPos;

    GameObject Target;
    EnemyScanner enemyScanner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = _shotInterval;
        enemyScanner = GetComponent<EnemyScanner>();
        _audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > _shotInterval)
        {
            timer = 0f;
            Shot();
            _audioSource.PlayOneShot(_arrowSound);
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        try
        {
            Target = enemyScanner.ScanWithFindTag();
            enemyPos = Target.transform.position;
        }
        catch
        {

        }
    }

    private void FixedUpdate()
    {
        
        //à⁄ìÆèàóù
        rb.MovePosition(rb.position + movement * _moveSpeed * Time.fixedDeltaTime);
        //É}ÉEÉXÇÃï˚å¸Ç…å¸Ç´ÇçáÇÌÇπÇÈ
        Vector2 lookDir = enemyPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    void Shot()
    {
        
        GameObject arrow = Instantiate(_arrowPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _arrowSpeed, ForceMode2D.Impulse);
    }

}
