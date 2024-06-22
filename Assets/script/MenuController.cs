using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject tabPanel;
    [SerializeField] GameObject gameOverPanel;
    bool tabMenuOpen;
    PlayerController playerController;
    private void Start()
    {
        CloseMenu();
        CloseGameOver();
        tabMenuOpen = false;
        GameObject obj = GameObject.Find("Player");
        playerController = obj.GetComponent<PlayerController>();
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

        if(playerController.HP <= 0)
        {
            GameOver();
        }
    }

    void OpenMenu()
    {
        Time.timeScale = 0;
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
