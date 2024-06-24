using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpRangeController : MonoBehaviour
{
    [SerializeField] float _destoryTime = 30f;
    public UnityEvent OnHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnHit.Invoke();
        }

    }

    IEnumerator ExpDestroy()
    {
        yield return new WaitForSeconds(_destoryTime);
        Destroy(gameObject);
    }

}
