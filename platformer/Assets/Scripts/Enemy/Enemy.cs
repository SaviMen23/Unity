using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyFollow _enemyFollow;
    [SerializeField] private Follower _follower;

    private void Update()
    {
        if (_enemyFollow != null)
            _enemyFollow.Renew();

        if (_follower != null)
            _follower.Renew();
    }
}