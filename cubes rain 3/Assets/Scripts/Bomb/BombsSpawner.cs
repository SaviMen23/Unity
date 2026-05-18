using UnityEngine;

public class BombsSpawner : Spawner<Bomb>
{
    [SerializeField] TargetsSpawner _targetsSpawner;

    private Vector3 _spawnPosition;

    private void OnEnable()
    {
        _targetsSpawner.TargetRespawn += SpawnInPlace;
    }

    private void OnDisable()
    {
        _targetsSpawner.TargetRespawn -= SpawnInPlace;
    }

    private void SpawnInPlace(Vector3 position)
    {
        _spawnPosition = position;
        Spawn();
    }

    protected override void Spawn()
    {
        Bomb bomb = _pool.Get();
        bomb.BombPooled += Respawn;
        bomb.transform.position = _spawnPosition;
        bomb.Work();
    }

    protected override void Respawn(Bomb bomb)
    {
        _pool.Return(bomb);
        bomb.BombPooled -= Respawn;
    }
}
