using System;
using UnityEngine;

public class StealZone : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;

    [field :SerializeField] public float Radius { get; private set; }

    public Collider2D[] GetEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, Radius, _enemyMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

