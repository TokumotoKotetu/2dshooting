using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScanner : MonoBehaviour
{
    [HideInInspector] public GameObject Target;

    public GameObject ScanWithFindTag()
    {
        GameObject[] _targets = GameObject.FindGameObjectsWithTag("Enemy");

        float tmp = float.MaxValue;
        foreach (GameObject o in _targets)
        {
            float distance_to_enemy = Vector3.Distance(transform.position, o.transform.position);
            if (distance_to_enemy < tmp)
            {
                tmp = distance_to_enemy;
                Target = o;
            }
        }
        return Target;
    }
}
