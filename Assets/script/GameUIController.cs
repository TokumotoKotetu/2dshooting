using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] Behaviour[] _heart;
    [SerializeField] Behaviour[] _redHeart;
    int _heartNumber = 2;
    public void Start()
    {

    }

    public void HeartDamage()
    {
        _redHeart[_heartNumber].enabled = false;
        _heartNumber -= 1;
    }
    public void LevelUPHeart()
    {
        _redHeart[0].enabled = true;
        _redHeart[1].enabled = true;
        _redHeart[2].enabled = true;
        _heartNumber = 2;
    }
    
    
}
