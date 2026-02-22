using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private SpawnHandler _spawnHandler;

    private void Awake()
    {
        _spawner.Initialize();
        _spawnHandler.FirstSpawn();
    }
}