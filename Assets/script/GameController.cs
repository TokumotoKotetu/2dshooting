using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int _score = 0;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _lvText;
    LevelController _levelController;
    public float _spawnMinusTime = 1;//àÍìxÇ…ÉXÉ|Å[Éìä¥äoÇå∏ÇÁÇ∑ïbêî
    [SerializeField]int _spawnLevel = 1;
    [SerializeField] int _spawnLevelNeedKill = 10;
    EnemySpawner _enemySpawner_up;
    EnemySpawner _enemySpawner_down;
    EnemySpawner _enemySpawner_right;
    EnemySpawner _enemySpawner_left;
    public int _level;
    public void Start()
    {
        GameObject obj = GameObject.Find("Player");
        _levelController = obj.GetComponent<LevelController>();
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
        _level = _levelController._level;
        _scoreText.text ="ìGÇì|ÇµÇΩêî :" + _score;
        _lvText.text = "Lv :" + _level;
        if (_score >= _spawnLevelNeedKill * _spawnLevel && _enemySpawner_up._spawnInterval > 1)
        {
            _spawnLevel += 1 + _levelController._level;
            _enemySpawner_up._spawnInterval -= _spawnMinusTime;   
            _enemySpawner_down._spawnInterval -= _spawnMinusTime;
            _enemySpawner_right._spawnInterval -= _spawnMinusTime;
            _enemySpawner_left._spawnInterval -= _spawnMinusTime;
        }
    }
}
