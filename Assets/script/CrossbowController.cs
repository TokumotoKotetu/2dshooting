using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrossbowController : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float shotInterval = 1f;
    [SerializeField] float arrowSpeed = 20f;
    [SerializeField] float moveSpeed = 1f;
    float timer = 0f;
    Rigidbody2D rb = default;
    Vector2 movement;
    Vector2 enemyPos;

    GameObject Target;
    EnemyScanner enemyScanner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = shotInterval;
        enemyScanner = GetComponent<EnemyScanner>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > shotInterval)
        {
            timer = 0f;
            Shot();
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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //É}ÉEÉXÇÃï˚å¸Ç…å¸Ç´ÇçáÇÌÇπÇÈ
        Vector2 lookDir = enemyPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    void Shot()
    {
        
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowSpeed, ForceMode2D.Impulse);
    }

}
