using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] public int _hp;
    [SerializeField] public int _experience;
    [SerializeField] public float _nextExperience;
    [SerializeField] public int _level;
    GameUIController _gameUIController;
    AudioSource _audioSource;
    [SerializeField] AudioClip _levelUpAudio;

    public void Start()
    {
        GameObject obj = GameObject.Find("UIPanel");
        _audioSource = GetComponent<AudioSource>();
        _gameUIController = obj.GetComponent<GameUIController>();
    }
    public void Damage()
    {
        _hp -= 1;
        _gameUIController.HeartDamage();
    }
    private void Update()
    {
        _nextExperience = Mathf.Pow(2, _level);

        if (_experience >= _nextExperience)
        {
            _experience = 0;
            LevelUp();
        }
    }
    public void LevelUp()
    {
        _level += 1;
        _hp = _maxHp;
        _gameUIController.LevelUPHeart();
        _audioSource.PlayOneShot(_levelUpAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Exp")
        {
            _experience += 1;
            Destroy(collision.gameObject);
        }
    }
}
