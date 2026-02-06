using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MoveAtSpeed
{
    void Update()
    {
        transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }
}
