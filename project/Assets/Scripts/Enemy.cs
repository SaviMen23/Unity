using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private bool _canWalk = false;

    private void Update()
    {
        if (_canWalk)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void StartWalk(Vector3 direction)
    {
        _direction = direction;
        transform.rotation = Quaternion.LookRotation(_direction);
        _canWalk = true;
    }
}
