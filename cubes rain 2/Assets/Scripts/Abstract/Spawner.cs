using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected Pool<T> _pool;

    public event Action<int> ObjectSpawned;

    private int _numberOfSpawned = 0;

    protected abstract T Spawn();

    protected abstract void Respawn(T spawnObject);

    protected void CountSpawnedObject()
    {
        ObjectSpawned?.Invoke(++_numberOfSpawned);
    }

    protected void OnGet()
    {

    }
}