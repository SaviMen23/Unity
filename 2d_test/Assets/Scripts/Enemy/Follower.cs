    using System;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    
    public event Action FollowerCame;

    private void Start()
    {
        FollowerCame?.Invoke();
    }

    public void SetTarget(Transform target) 
    {
        _target = target; 
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            FollowerCame?.Invoke();
    }
}
