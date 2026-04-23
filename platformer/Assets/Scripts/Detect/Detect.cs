using System;
using Unity.VisualScripting;
using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Color _colorCircle;
    [SerializeField] private bool _canDeleteFollowerComponent;

    public event Action<Transform> EnemySet;
    public event Action<float> RadiusChanged;

    private void Start()
    {
        RadiusChanged?.Invoke(_detectRadius);
    }

    private void FixedUpdate()
    {
        TryDetect();
    }

    private void TryDetect()
    {
        Collider2D detectCollider = Physics2D.OverlapCircle(transform.position, _detectRadius, _layerMask);

        if (detectCollider != null)
        {
            EnemySet?.Invoke(detectCollider.gameObject.transform);
            
            if (_canDeleteFollowerComponent)
            {
                gameObject.TryGetComponent(out Follower follower);
                Destroy(follower);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _colorCircle;
        Gizmos.DrawWireSphere(transform.position, _detectRadius);
    }
}