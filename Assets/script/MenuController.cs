using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject tabPanel;
    [SerializeField] GameObject gameOverCanvas;
    LevelController _levelController;
    private void Start()
    {
        CloseMenu();
        CloseGameOver();
        GameObject obj = GameObject.Find("Player");
        _levelController = obj.GetComponent<LevelController>();
    }
    private void Update()
    {
        if(_levelController._hp <= 0)
        {
            GameOver();
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0.1f;
        tabPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        tabPanel.SetActive(false);
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
    void CloseGameOver()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
    }
}
