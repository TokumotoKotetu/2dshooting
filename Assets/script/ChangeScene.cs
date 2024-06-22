using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void LoadToStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void LoadToGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
