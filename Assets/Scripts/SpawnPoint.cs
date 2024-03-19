using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Target[] _purposes;

    private Vector3 _direction;

    public void SpawnEnemies()
    {
        Enemy enemy;
        int minNumberPurpose = 0;
        int numberPurpos;

        numberPurpos = Random.Range(minNumberPurpose, _purposes.Length);

        _direction = (_purposes[numberPurpos].transform.position - transform.position).normalized;

        enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.LookRotation(_direction));

        enemy.SetDirection(_direction);
    }
}