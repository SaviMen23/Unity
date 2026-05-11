using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] private Follower _follower;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private void OnEnable()
    {
        _follower.FollowerCame += SetFollowerTarget;
    }

    private void OnDisable()
    {
        _follower.FollowerCame -= SetFollowerTarget;
    }

    private void SetFollowerTarget()
    {
        if (_follower.transform.position == _firstPoint.position)
            _follower.SetTarget(_secondPoint);
        else if (_follower.transform.position == _secondPoint.position)
            _follower.SetTarget(_firstPoint);
        else
            _follower.SetTarget(_firstPoint);
    }
}
