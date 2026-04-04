using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action TargetSet;

    private Transform _target;

    private void Start()
    {
        TargetSet?.Invoke();
    }

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target) => _target = target;

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            TargetSet?.Invoke();
    }
}
