using UnityEngine;

public class FirstAidKitCollector : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FirstAidKit component))
            component.Use(_playerHealth);
    }
}
