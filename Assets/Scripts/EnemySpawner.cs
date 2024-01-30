using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSeconds _wait;
    private Vector3 _direction;
    private float _spawnTime = 2.0f;

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnTime);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Transform spawnPoint;
        Rigidbody enemy;

        int minSpawnPointValue = 0;
        float angle;

        while (true)
        {
            yield return _wait;

            angle = Random.Range(110.0f, 250.0f);

            _direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            spawnPoint = _spawnPoints[Random.Range(minSpawnPointValue, _spawnPoints.Length)];

            enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.LookRotation(_direction));

            enemy.GetComponent<Enemy>().SetDirection(_direction);
        }
    }
}