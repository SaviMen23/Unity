using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CubeMoveAndRotate : MoveAtSpeed
{
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        transform.localScale += new Vector3(1f, 1f, 1f) * _scaleSpeed * Time.deltaTime;
        transform.Translate(transform.forward * _speed * Time.deltaTime);
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }
}
