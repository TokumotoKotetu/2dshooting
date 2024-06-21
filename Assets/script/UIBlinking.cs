using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlinking : MonoBehaviour
{
    [SerializeField] private Behaviour _target;
    /// <summary> “_–ÅŽüŠú[s] </summary>
    [SerializeField] private float _cycle = 1;
    private double _time;

    void Update()
    {
        _time = Time.deltaTime;

        var repeatValue = Mathf.Repeat((float)_time, _cycle);

        _target.enabled = repeatValue >= _cycle * 0.5f;
    }
}
