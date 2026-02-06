using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MoveAtSpeed
{
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
