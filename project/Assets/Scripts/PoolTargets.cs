using System.Collections.Generic;
using UnityEngine;

public class PoolTargets
{
    private Target _prefab;
    private Queue<Target> _targets;
    private Color _prefabColor;
    private int _poolCapacity;

    public PoolTargets(Target prefab, int capacity) 
    {
        _prefab = prefab;
        _poolCapacity = capacity;
        Initialize();
        Fill();
    }

    public Target Get()
    {
        if (_targets.Count == 0)
            ExpandPool();

        Target target = _targets.Dequeue();
        target.gameObject.SetActive(true);

        return target;
    }

    public void Return(Target target)
    {
        target.Clear(_prefabColor);
        target.gameObject.SetActive(false);
        _targets.Enqueue(target);
    }

    private void Initialize()
    {
        _targets = new Queue<Target>();
        _prefabColor = _prefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    private void Fill()
    {
        for (int i = 0; i < _poolCapacity; i++)
            _targets.Enqueue(GameObject.Instantiate(_prefab));

        foreach (Target target in _targets)
            target.gameObject.SetActive(false);
    }

    private void ExpandPool()
    {
        Target target = GameObject.Instantiate(_prefab);
        target.gameObject.SetActive(false);
        _targets.Enqueue(target);
    }
}
