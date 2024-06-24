using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public int _score = 0;
    public float _spawnMinusTime = 1;//一度にスポーン感覚を減らす秒数
    [SerializeField]int _spawnLevel = 1;
    [SerializeField] int _spawnLevelNeedKill = 10;
    EnemySpawner _enemySpawner_up;
    EnemySpawner _enemySpawner_down;
    EnemySpawner _enemySpawner_right;
    EnemySpawner _enemySpawner_left;
    public void Start()
    {
        GameObject objup = GameObject.Find("Spawner_up");
        GameObject objdown = GameObject.Find("Spawner_down");
        GameObject objright = GameObject.Find("Spawner_right");
        GameObject objleft = GameObject.Find("Spawner_left");

        _enemySpawner_up = objup.GetComponent<EnemySpawner>();
        _enemySpawner_down = objdown.GetComponent<EnemySpawner>();
        _enemySpawner_right = objright.GetComponent<EnemySpawner>();
        _enemySpawner_left = objleft.GetComponent<EnemySpawner>();
    }
    public void Update()
    {

        if (_score >= _spawnLevelNeedKill * _spawnLevel && _enemySpawner_up._spawnInterval > 1)
        {
            _spawnLevel += 1;
            _enemySpawner_up._spawnInterval -= _spawnMinusTime;   
            _enemySpawner_down._spawnInterval -= _spawnMinusTime;
            _enemySpawner_right._spawnInterval -= _spawnMinusTime;
            _enemySpawner_left._spawnInterval -= _spawnMinusTime;
        }
    }
}
