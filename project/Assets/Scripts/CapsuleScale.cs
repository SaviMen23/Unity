using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScale : MoveAtSpeed
{
    void Update()
    {
        transform.localScale += new Vector3(1f, 1f, 1f) * _speed * Time.deltaTime;
    }
}
