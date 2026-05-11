using System;
using System.Collections;
using UnityEngine;

public class StealerHealth : MonoBehaviour
{
    [SerializeField] private StealZone _range;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _stolenHealth;

    [field: SerializeField] public float AbilityDurationTime;
    [field: SerializeField] public float AbilityReloadTime;

    public event Action AbilityWork;

    private const float DelayPerSecond = 1f;

    private bool _canWork = true;
    private float _beginningAbility;
    private WaitForSecondsRealtime _delayPerSecondForCoroutine;
    private WaitForSecondsRealtime _delayReloadForCoroutine;

    public void Initialize()
    {
        _delayPerSecondForCoroutine = new WaitForSecondsRealtime(DelayPerSecond);
        _delayReloadForCoroutine = new WaitForSecondsRealtime(AbilityReloadTime);
    }

    public void Work()
    {
        _beginningAbility = Time.time;

        if (_canWork)
        {
            StartCoroutine(StealWithDelay());
            AbilityWork?.Invoke();
        }
    }

    private IEnumerator StealWithDelay()
    {
        _canWork = false;

        while (Time.time - _beginningAbility <= AbilityDurationTime)
        {
            Collider2D[] currentNumberOfEnemies = _range.GetEnemies();

            if (currentNumberOfEnemies.Length != 0)
            {
                Collider2D enemy = FindClosest(currentNumberOfEnemies);
                StealHealth(enemy);
            }

            yield return _delayPerSecondForCoroutine;
        }

        yield return _delayReloadForCoroutine;

        _canWork = true;
    }

    private Collider2D FindClosest(Collider2D[] enemies)
    {
        Collider2D closestEnemy = null;
        float distanceToClosestEnemy = float.MaxValue;

        foreach (Collider2D enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (distance < distanceToClosestEnemy)
            {
                closestEnemy = enemy;
                distanceToClosestEnemy = distance;
            }
        }

        return closestEnemy;
    }

    private void StealHealth(Collider2D enemy)
    {
        if (enemy.TryGetComponent(out Health enemyHealth))
        {
            enemyHealth.TakeDamage(_stolenHealth);
            _playerHealth.Heal(_stolenHealth);
        }
    }
}

