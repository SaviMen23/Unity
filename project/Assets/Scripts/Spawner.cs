using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0)] private float _delay;
    [Space(20)]
    [SerializeField] private bool _autoFillSpawnPoints = false;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private WaitForSecondsRealtime _delayForCoroutine;
    private int _minForArrays = 0;

    private void Awake()
    {
        _delayForCoroutine = new WaitForSecondsRealtime(_delay);

        if (_autoFillSpawnPoints)
            FillSpawnPoints();
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawnWithDelay));
    }

    private void FillSpawnPoints()
    {
        foreach (Transform spawnPoint in transform)
        {
            _spawnPoints.Add(spawnPoint?.GetComponent<SpawnPoint>());
        }
    }

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return _delayForCoroutine;

            _spawnPoints[Random.Range(_minForArrays, _spawnPoints.Count)].Spawn();
        }
    }
}
