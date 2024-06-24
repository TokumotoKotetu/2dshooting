using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpSliderController : MonoBehaviour
{
    [SerializeField] Slider _expSlider;
    LevelController _levelController;
    int _exp;
    float _nextExp;

    void Start()
    {
        GameObject obj = GameObject.Find("Player");
        _levelController = obj.GetComponent<LevelController>();
        _expSlider = GetComponent<Slider>();
    }

    void Update()
    {
        _exp = _levelController._experience;
        _nextExp = _levelController._nextExperience;
        _expSlider.maxValue = _nextExp;
        _expSlider.value = _exp;
    }
}
