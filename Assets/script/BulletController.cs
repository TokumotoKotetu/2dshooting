using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(obDestroy), 3.5f);

    }

    private void obDestroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
        else
        {
            //Destroy(this.gameObject);
        }
        
    }

}
