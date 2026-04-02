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
        _follower.TargetSet += SetFollowerTarget;
    }

    private void OnDisable()
    {
        _follower.TargetSet -= SetFollowerTarget;
    }

    private Transform SetFollowerTarget(Transform currentTarget)
    {
        if(currentTarget == null) 
            return _firstPoint;

        return currentTarget == _secondPoint ? _firstPoint : _secondPoint;
    }
}
