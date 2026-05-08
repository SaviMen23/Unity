using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int Max { get; private set; }

    public event Action<int> HealthChanged;

    private int _current;


    private void Awake()
    {
        _current = Max;
    }

    public void TakeDamage(int damage)
    {
        if (_current - damage > 0)
            _current -= damage;
        else
        {
            _current = 0;
            Die();
        }

        HealthChanged?.Invoke(_current);
    }

    public void Heal(int healthByHeal)
    {
        if (_current + healthByHeal <= Max)
            _current += healthByHeal;
        else
            _current = Max;

        HealthChanged?.Invoke(_current);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
