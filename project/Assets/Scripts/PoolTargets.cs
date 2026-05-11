using System.Collections.Generic;
using UnityEngine;

public class PoolTargets : MonoBehaviour
{
    [SerializeField] private Target _prefab;
    [SerializeField] private int _poolCapacity;

    private Queue<Target> _targets;
    private Color _prefabColor;

    public Target Get()
    {
        if(_targets.Count == 0)
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

    private void Awake()
    {
        _targets = new Queue<Target>();
        _prefabColor = _prefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    private void Start()
    {
        for (int i = 0; i < _poolCapacity; i++)
            _targets.Enqueue(Instantiate(_prefab));

        foreach (Target target in _targets)
            target.gameObject.SetActive(false);
    }

    private void ExpandPool()
    {
        Target target = Instantiate(_prefab);
        target.gameObject.SetActive(false);
        _targets.Enqueue(target);
    }
}
