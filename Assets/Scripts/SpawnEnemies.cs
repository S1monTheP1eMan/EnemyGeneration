using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _delay;
    [SerializeField] private float _totalSpawnTime;

    private Transform[] _points;
    private float _runningTime;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (_runningTime <= _totalSpawnTime)
        {
            Debug.Log("Enemy has spawned!");
            Instantiate(_template, _points[GetRandomPoint()].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    private int GetRandomPoint()
    {
        int randomPoint = Random.Range(0, transform.childCount);
        return randomPoint;
    }
}
