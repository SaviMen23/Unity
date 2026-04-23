using UnityEngine;

public class firstAidKit : MonoBehaviour
{
    [SerializeField, Min(0)] private int _healthRecovery;
    [SerializeField, Min(0)] private float _takeRadius;
    [SerializeField] private LayerMask _playerMask;

    public void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _takeRadius, _playerMask);
        TryUse(collider);
    }

    private void TryUse(Collider2D collider)
    {
        if (collider != null)
            if (collider.TryGetComponent(out Health playerHealth))
            {
                playerHealth.Heal(_healthRecovery);
                gameObject.SetActive(false);
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _takeRadius);
    }
}
