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
    PlayerController _playerController;
    [SerializeField] AudioClip _levelUpAudio;
    [SerializeField] GameObject _levelupPanel;


    public void Start()
    {
        GameObject obj = GameObject.Find("UIPanel");
        _audioSource = GetComponent<AudioSource>();
        GameObject obj1 = GameObject.Find("Player");
        _playerController = obj1.GetComponent<PlayerController>();
        _gameUIController = obj.GetComponent<GameUIController>();
        Time.timeScale = 0.1f;
        _levelupPanel.SetActive(true);
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
        if(_playerController._haveWeaponNumber < _playerController.weaponPos.Length)
        {
            Time.timeScale = 0.01f;
            _levelupPanel.SetActive(true);
        }

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
