using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Func<Transform,Transform> TargetSet;

    private Transform _target;

    private void Start()
    {
       _target = TargetSet?.Invoke(null);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
           _target = TargetSet?.Invoke(_target);
    }

    private void SetTarget(Transform target) => _target = target;
}
