using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected Pool<T> _pool;

    public event Action<int> ObjectSpawned;

    private int numberOfSpawned = 0;

    protected virtual void Spawn()
    {
        ObjectSpawned?.Invoke(++numberOfSpawned);
    }

    protected abstract void Respawn(T spawnObject);
}