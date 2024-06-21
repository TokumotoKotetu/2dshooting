using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GunController : MonoBehaviour
{
    //�e�ۂ̃v���t�@�u
    [SerializeField] GameObject bulletPrefab;
    //�Ə�
    [SerializeField] Transform firePoint;
    //���˂̃C���^�[�o��
    [SerializeField] float shotInterval = 1.0f;
    //�e�e�̑��x
    [SerializeField] float bulletspeed = 20f;
    [SerializeField] Camera cam;
    //�ړ����x
    [SerializeField] float moveSpeed = 1f;
    float timer;
    Rigidbody2D rb = default;
    Vector2 mousePos;
    Vector2 movement;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = shotInterval;
        cam = Camera.main;
        
    }
    void Update()
    {
        timer += Time.deltaTime;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0) && timer > shotInterval) 
        {
            timer = 0;
            Shot();
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //�ړ�����
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //�}�E�X�̕����Ɍ��������킹��
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    void Shot() //�e�۔��ˏ���
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletspeed, ForceMode2D.Impulse);
    }

 
}
