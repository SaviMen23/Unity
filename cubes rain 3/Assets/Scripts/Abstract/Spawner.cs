using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected Pool<T> _pool;

    protected abstract void Spawn();

    protected abstract void Respawn(T spawnObject);
}


