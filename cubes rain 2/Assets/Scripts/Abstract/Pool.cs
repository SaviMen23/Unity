using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected T _prefab;
    [SerializeField, Min(0)] protected int _startCapacity;

    public event Action<int> PoolExpand;
    public event Action<int> NumberOfActiveChange;

    protected Queue<T> _queue;
    protected int _capacity;

    protected virtual void Awake()
    {
        _queue = new Queue<T>();
        _capacity = _startCapacity;
    }

    protected virtual void Start()
    {
        for (int i = 0; i < _startCapacity; i++)
            _queue.Enqueue(Instantiate(_prefab));

        foreach (T poolObject in _queue)
            poolObject.gameObject.SetActive(false);

        PoolExpand?.Invoke(_capacity);
    }

    public abstract T Get();

    public virtual void Return(T poolObject)
    {
        ChangeCounterActiveObjects();
    }

    protected virtual void ExpandPool()
    {
        PoolExpand?.Invoke(++_capacity);
        ChangeCounterActiveObjects();
    }

    protected void ChangeCounterActiveObjects()
    {
        NumberOfActiveChange?.Invoke(_capacity - _queue.Count);
    }

    protected void OnGet()
    {

    }
}


