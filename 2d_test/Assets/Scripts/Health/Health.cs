using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Max { get; private set; }

    public event Action<int> HealthChanged;

    private int _positiveSign = 1;
    private int _negativeSign = -1;
    private int _current;
    private int _min = 0;

    private void Awake()
    {
        _current = Max;
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(damage, _negativeSign);
    }
    
    public void Heal(int healthByHeal)
    {
        ChangeHealth(healthByHeal, _positiveSign);
    }

    private void ChangeHealth(int delta, int sign)
    {
        _current += Math.Clamp(delta, _min, Max) * sign;

        if (_current <= _min)
            Die();

        HealthChanged?.Invoke(_current);
    }
    
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
