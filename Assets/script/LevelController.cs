using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField] int _experience;
    [SerializeField] float _nextExperience;
    [SerializeField] int _level;
    public void Start()
    {
    }
    public void Damege()
    {
        _hp -= 1;
        if( _hp <= 0)
        {
            //Ž€–S”»’è
        }
    }
    private void Update()
    {
        _nextExperience = Mathf.Pow(2, _level);

        if (_experience >= _nextExperience)
        {
            _experience = 0;
            LevelUp();
        }
    }
    public void LevelUp()
    {
        _level += 1;
        _hp = _maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Exp")
        {
            _experience += 1;
            Destroy(collision.gameObject);
        }
    }
}
