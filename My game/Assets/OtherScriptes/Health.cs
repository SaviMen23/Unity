using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.tvOS;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action<int> HealthChanged;

    private int _health;

    public int MaxHealth { get { return _maxHealth; } }

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_health - damage > 0)
            _health -= damage;
        else
        {
            _health = 0;
            Die();
        }

        HealthChanged?.Invoke(_health);
    }

    public void Heal(int healthByHeal)
    {
        if (_health + healthByHeal <= _maxHealth)
            _health += healthByHeal;
        else
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Debug.Log($"{transform.root.name} мертв");
    }
}
