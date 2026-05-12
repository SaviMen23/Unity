using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolTargets _poolTargets;
    [SerializeField] private int _startQuality;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        for (int i = 0; i < _startQuality; i++)
            Spawn();
    }

    private void Spawn()
    {
        float colliderBoundsX = _collider.bounds.size.x / 2;
        float colliderBoundsY = _collider.bounds.size.y / 2;
        float colliderBoundsZ = _collider.bounds.size.z / 2;

        Vector3 position = new Vector3(Random.Range(-colliderBoundsX,colliderBoundsX + 1), Random.Range(-colliderBoundsY,
        colliderBoundsY + 1), Random.Range(-colliderBoundsZ, colliderBoundsZ + 1)) + transform.position;
        Target target = _poolTargets.Get();
        target.TargetPooled += RespawnTarget;
        target.transform.position = position;
    }

    private void RespawnTarget(Target target)
    {
        _poolTargets.Return(target);
        Spawn();
    }
}
