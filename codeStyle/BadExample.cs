using System.Collections;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _parentPoint;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private Transform _currentTarget;
    private int _positionIndex;

    private void Start()
    {
        _places = new Transform[_parentPoint.childCount];

        for (int i = 0; i < _parentPoint.childCount; i++)
            _places[i] = _parentPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        _currentTarget = _places[_positionIndex];
        Move();

        if (transform.position == _currentTarget.position)
            ChangePointPosition();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
        transform.LookAt(_currentTarget);
    }

    private void ChangePointPosition()
    {
        if (++_positionIndex == _places.Length)
            _positionIndex = 0;
    }
}