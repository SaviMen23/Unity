using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private Health _characterHealth;

    private void Start()
    {
        Slider.maxValue = _characterHealth.MaxHealth;
        Slider.value = Slider.maxValue;
    }

    private void OnEnable()
    {
        _characterHealth.HealthChanged += ChangeBar;
    }

    private void OnDisable()
    {
        _characterHealth.HealthChanged -= ChangeBar;
    }

    protected virtual void ChangeBar(int heanthPoints)
    {
        Slider.value = heanthPoints;
    }
}
