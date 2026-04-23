using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += Show;  
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Show;
    }

    private void Show(int health)
    {
        Debug.Log($"Здоровье {transform.root.name}: {health}");
    }
}
