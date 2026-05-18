using UnityEngine;
using System.Collections.Generic;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected T _prefab;
    [SerializeField, Min(0)] protected int _poolCapacity;

    protected Queue<T> _queue;

    protected virtual void Awake()
    {
        _queue = new Queue<T>();
    }

    protected virtual void Start()
    {
        for (int i = 0; i < _poolCapacity; i++)
            _queue.Enqueue(Instantiate(_prefab));

        foreach (T poolObject in _queue)
            poolObject.gameObject.SetActive(false);
    }

    public abstract T Get();

    public abstract void Return(T poolObject);

    protected abstract void ExpandPool();
}


