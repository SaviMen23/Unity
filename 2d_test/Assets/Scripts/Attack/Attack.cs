using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Attack : MonoBehaviour
{
    [SerializeField] private Detect _detect;
    [SerializeField] private int _damage;
    [SerializeField] private float _delayOfAttack;

    private float _lastAttackTime = 0f;

    private void OnEnable()
    {
        _detect.EnemySet += TryHit;
    }

    private void OnDisable()
    {
        _detect.EnemySet -= TryHit;
    }

    private void TryHit(Transform enemy)
    {
        if (Time.time >= _lastAttackTime + _delayOfAttack)
            Hit(enemy);
    }   

    private void Hit(Transform enemy)
    {
        if (enemy.TryGetComponent(out Health healthEnemy))
        {
            healthEnemy.TakeDamage(_damage);
            _lastAttackTime = Time.time;
        }
    }
}
