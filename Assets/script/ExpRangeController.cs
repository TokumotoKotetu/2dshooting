using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpRangeController : MonoBehaviour
{
    public UnityEvent OnHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnHit.Invoke();
        }

    }
}
