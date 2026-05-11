using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyFollow;
    [SerializeField] private Follower _follower;

    private void Update()
    {
        if (_enemyFollow != null)
            _enemyFollow.Move();

        if (_follower != null)
            _follower.Move();
    }
}