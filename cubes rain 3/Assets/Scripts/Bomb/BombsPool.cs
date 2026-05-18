using UnityEngine;

public class BombsPool : Pool<Bomb>
{
    public override Bomb Get()
    {
        if (_queue.Count == 0)
            ExpandPool();

        Bomb bomb = _queue.Dequeue();
        bomb.gameObject.SetActive(true);

        return bomb;
    }

    public override void Return(Bomb poolObject)
    {
        if (poolObject.TryGetComponent(out Rigidbody targetRigidbody))
        {
            targetRigidbody.velocity = Vector3.zero;
            targetRigidbody.angularVelocity = Vector3.zero;
        }

        poolObject.transform.rotation = Quaternion.identity;
        poolObject.gameObject.SetActive(false);
        _queue.Enqueue(poolObject);
    }

    protected override void ExpandPool()
    {
        Bomb bomb = Instantiate(_prefab);
        bomb.gameObject.SetActive(false);
        _queue.Enqueue(bomb);
    }
}
