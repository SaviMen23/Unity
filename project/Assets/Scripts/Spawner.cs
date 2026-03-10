using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField] private Vector3 _direction;
    [Space(20)]
    [SerializeField] private Transform[] _spawnPoints;

    private WaitForSecondsRealtime _delayForCoroutine;
    private int _minForArrays = 0;

    private void Awake()
    {
        _delayForCoroutine = new WaitForSecondsRealtime(_delay);
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawnWithDelay));
    }

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return _delayForCoroutine;

            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[Random.Range(_minForArrays, _spawnPoints.Length)]);
            enemy.StartWalk(_direction.normalized);
        }
    }
}
