using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject tabPanel;
    bool tabMenuOpen;
    private void Start()
    {
        CloseMenu();
        tabMenuOpen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && tabMenuOpen == false)
        {
            Debug.Log("���j���[���J����");
            OpenMenu();
            tabMenuOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && tabMenuOpen == true)
        {
            Debug.Log("���j���[������");
            CloseMenu();
            tabMenuOpen = false;
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
}
