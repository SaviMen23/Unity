using System;
using UnityEngine;

public class StealZone : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;

    [field :SerializeField] public float Radius { get; private set; }

    public Collider2D[] GetEnemies()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, Radius, _enemyMask);

        return enemyColliders;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

