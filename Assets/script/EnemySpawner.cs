using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _prefabToSpawn;
    [SerializeField] public float _spawnInterval;
    GameController _gameController;
    private BoxCollider2D _boxCollider2D;
    bool _isPose = false;
    float time = 0;
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnObject());
        GameObject obj = GameObject.Find("GameController");
        _gameController = obj.GetComponent<GameController>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 30)
        {
            if(time >= 10)
            {
                _spawnInterval = 1;
            }
            else
            {
                _spawnInterval = 3;
            }
        }
    }
    IEnumerator SpawnObject()
    {
        while (true)
        {
            if (!_isPose)
            {
                float randomX = Random.Range(-_boxCollider2D.size.x, _boxCollider2D.size.x) * .5f;
                float randomY = Random.Range(-_boxCollider2D.size.y, _boxCollider2D.size.y) * .5f;

                GameObject newObject = Instantiate<GameObject>(_prefabToSpawn);
                newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);
            }
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void InPose()
    {
        _isPose = true;
    }
    public void OutPose()
    {
        _isPose = false;
    }
}
