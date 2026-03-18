using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    public event Action<bool> BodyWent;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private bool _isWalk;

    public void Update()
    {
        Move(Input.GetAxis(Vertical));
        Rotate(Input.GetAxis(Horizontal));
    }

    private void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * direction * _rotateSpeed * Time.deltaTime);
    }

    private void Move(float direction)
    {
        if (_isWalk == false && direction != 0)
        {
            _isWalk = true;
            BodyWent?.Invoke(_isWalk);
        }

        if (_isWalk && direction == 0)
        {
            _isWalk = false;
            BodyWent?.Invoke(_isWalk);
        }

        transform.Translate(Vector3.forward * direction * _moveSpeed * Time.deltaTime);
    }
}

