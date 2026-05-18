using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class TargetsSpawner : Spawner<Target>
{
    [SerializeField] protected int _startQuality;

    private Collider _collider;

    public event Action<Vector3> TargetRespawn;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        for (int i = 0; i < _startQuality; i++)
            Spawn();
    }

    protected override void Spawn()
    {
        float colliderBoundsX = _collider.bounds.size.x / 2;
        float colliderBoundsY = _collider.bounds.size.y / 2;
        float colliderBoundsZ = _collider.bounds.size.z / 2;

        Vector3 position = new Vector3(Random.Range(-colliderBoundsX,colliderBoundsX + 1), Random.Range(-colliderBoundsY,
        colliderBoundsY + 1), Random.Range(-colliderBoundsZ, colliderBoundsZ + 1)) + transform.position;
        Target target = _pool.Get();
        target.TargetPooled += Respawn;
        target.transform.position = position;
    }

    protected override void Respawn(Target target)
    {
        TargetRespawn?.Invoke(target.transform.position);
        _pool.Return(target);
        target.TargetPooled -= Respawn;
        Spawn();
    }
}
