using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputHandler;
    [SerializeField] private float _moveSpeed;

    private void OnEnable()
    {
        _inputHandler.AxisGot += Move;
    }

    private void OnDisable()
    {
        _inputHandler.AxisGot -= Move;
    }

    private void Move(float direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime * Vector2.right);
    }
}
