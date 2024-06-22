using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class UIBlinking : MonoBehaviour
{
    /// <summary> “_–ÅŽüŠú[s] </summary>
    [SerializeField] private float _cycle = 1;
    private float _time;
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    void Update()
    {
        _text.color = GetTextColoer(_text.color);

    }
    Color GetTextColoer(Color color)
    {
       _time += Time.deltaTime * _cycle;
        color.a = Mathf.Sin(_time);
        return color;
    }
}
