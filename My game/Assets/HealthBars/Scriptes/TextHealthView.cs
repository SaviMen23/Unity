using UnityEngine;
using TMPro;

public class TextHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _currentHealthText;

    private void OnEnable()
    {
        _health.HealthChanged += ChangeText;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeText;
    }

    private void Start()
    {
        ChangeText(_health.MaxHealth);
    }

    private void ChangeText(int health)
    {
        _currentHealthText.text = $"{health}/{_health.MaxHealth}";
    }
}
