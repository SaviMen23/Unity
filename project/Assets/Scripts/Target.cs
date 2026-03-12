using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _currentPoint;
    private int _currentPointIndex;
    private int _maxPointIndex;

    public event Func<int, Vector3> IndexChanged;

    private void Update()
    {
        Move();
    }

    public void Initialize(Vector3 startPosition, int index, int maxPointIndex)
    {
        transform.position = startPosition;
        _currentPointIndex = index + 1;
        _maxPointIndex = maxPointIndex;
        _currentPoint = (Vector3)IndexChanged?.Invoke(_currentPointIndex);
    }

    public void SetNextIndex()
    {
        if (++_currentPointIndex == _maxPointIndex)
            _currentPointIndex = 0;
        
        _currentPoint = (Vector3)IndexChanged?.Invoke(_currentPointIndex);
    }

    private void Move()
    {
        if (transform.position == _currentPoint)
            SetNextIndex();

        transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);
    }
}
