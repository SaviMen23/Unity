using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;

    public void Spawn()
    {
       Enemy enemy =  Instantiate(_enemyPrefab,transform.position, Quaternion.identity);
        enemy.SetTarget(_target);
    }
}
