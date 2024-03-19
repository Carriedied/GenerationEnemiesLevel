using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private WaitForSeconds _wait;
    private float _spawnTime = 2.0f;

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnTime);
        StartCoroutine(ChoiceSpawn());
    }

    private IEnumerator ChoiceSpawn()
    {
        int numberSpawn;
        int minSpawnPointValue = 0;

        while (true)
        {
            yield return _wait;

            numberSpawn = UnityEngine.Random.Range(minSpawnPointValue, _spawnPoints.Length);

            _spawnPoints[numberSpawn].SpawnEnemies();
        }
    }
}
