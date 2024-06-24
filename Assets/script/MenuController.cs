using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject tabPanel;
    [SerializeField] GameObject gameOverPanel;
    bool tabMenuOpen;
    LevelController _levelController;
    private void Start()
    {
        CloseMenu();
        CloseGameOver();
        tabMenuOpen = false;
        GameObject obj = GameObject.Find("Player");
        _levelController = obj.GetComponent<LevelController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && tabMenuOpen == false)
        {
            Debug.Log("メニューが開いた");
            OpenMenu();
            tabMenuOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && tabMenuOpen == true)
        {
            Debug.Log("メニューが閉じた");
            CloseMenu();
            tabMenuOpen = false;
        }

        if(_levelController._hp <= 0)
        {
            GameOver();
        }
    }

    void OpenMenu()
    {
        Time.timeScale = 0.5f;
        tabPanel.SetActive(true);
    }

    void CloseMenu()
    {
        Time.timeScale = 1;
        tabPanel.SetActive(false);
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    void CloseGameOver()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }
}
