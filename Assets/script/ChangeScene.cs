using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void LoadToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
