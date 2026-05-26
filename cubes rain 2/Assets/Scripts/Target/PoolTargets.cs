using UnityEngine;

public class PoolTargets : Pool<Target>
{
    private Color _prefabColor;

    protected override void Awake()
    {
        base.Awake();
        _prefabColor = _prefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    public override Target Get()
    {
        if(_queue.Count == 0)
            ExpandPool();

        Target target = _queue.Dequeue();
        target.gameObject.SetActive(true);
        ChangeCounterActiveObjects();

        return target;
    }

    public override void Return(Target target)
    {
        if (target.TryGetComponent(out Rigidbody targetRigidbody))
        {
            targetRigidbody.velocity = Vector3.zero;
            targetRigidbody.angularVelocity = Vector3.zero;
        }

        target.transform.rotation = Quaternion.identity;
        target.Clear(_prefabColor);
        target.gameObject.SetActive(false);
        _queue.Enqueue(target);
        base.Return(target);    
    }

    protected override void ExpandPool()
    {
        Target target = Instantiate(_prefab);
        target.gameObject.SetActive(false);
        _queue.Enqueue(target);
        base.ExpandPool();
    }
}
