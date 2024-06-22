using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    public void change_button()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
    }
}
