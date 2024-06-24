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
    [SerializeField] Text _endScoreText;
    [SerializeField] Text _clearScoreText;
    [SerializeField] int _timeLimit = 60;
    [SerializeField] Text _timerText;
    [SerializeField] Text _endTimerText;
    [SerializeField] GameObject _gameClearCanvas;
    LevelController _levelController;

    public int _level;
    float time;
    public void Start()
    {
        GameObject obj = GameObject.Find("Player");
        _levelController = obj.GetComponent<LevelController>();
        _gameClearCanvas.SetActive(false);
    }
    public void Update()
    {
        time += Time.deltaTime;
        int remaining = _timeLimit - (int)time;
        _timerText.text = $"ÇÃÇ±ÇË:{remaining.ToString("D3")}";
        _endTimerText.text = $"ÇÃÇ±ÇË:{remaining.ToString("D3")}ïb";
        _level = _levelController._level - 2;
        _scoreText.text ="ìGÇì|ÇµÇΩêî :" + _score;
        _endScoreText.text = "ìGÇì|ÇµÇΩêî :" + _score;
        _clearScoreText.text = "ìGÇì|ÇµÇΩêî :" + _score;
        _lvText.text = "Lv :" + _level ;     
        
        if(_timeLimit < time)
        {
            _gameClearCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
