using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public int HP = 3;
    [SerializeField] int _bulletDamage = 1;
    [SerializeField] int _arrowDamage = 2;

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
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
