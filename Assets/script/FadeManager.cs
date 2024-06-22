using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    /// <summary> フェードするスピード</summary>
    [SerializeField] float _fadeSpeed = 0.2f;
    float _red, _green, _blue, _alfa;

    [SerializeField] bool _out = false;
    [SerializeField] bool _in = false;
    Image fadePanel;

    void Start()
    {
        fadePanel = GetComponent<Image>();
        _red = fadePanel.color.r;
        _green = fadePanel.color.g;
        _blue = fadePanel.color.b;
        _alfa = fadePanel.color.a;
    }

    void Update()
    {
        if (_in)
        {
            FadeIn();
        }

        if (_out)
        {
            FadeOut();
        }
    }
    void FadeIn()
    {
        _alfa -= _fadeSpeed;
        Alpha();
        if (_alfa <= 0)
        {
            _in = false;
            fadePanel.enabled = false;
        }

    }
    void FadeOut()
    {
        fadePanel.enabled = true;
        _alfa += _fadeSpeed;
        Alpha();
        if(_alfa >= 1)
        {
            _out = false;
        }
    }
    void Alpha()
    {
        fadePanel.color = new Color(_red, _green, _blue, _alfa);
    }
}
