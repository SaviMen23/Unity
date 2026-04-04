using UnityEngine;

public class HostWallet : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _collectionRadius;
    [SerializeField] private Vector3 _offsetCollection;
    [SerializeField] private LayerMask _coinMask;

    private void Update()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position + _offsetCollection, _collectionRadius, _coinMask.value);

        if(targetCollider == null)
            return;
        
        if (targetCollider.TryGetComponent(out Coin coin))
            coin.Take();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + _offsetCollection, _collectionRadius);
    }
}