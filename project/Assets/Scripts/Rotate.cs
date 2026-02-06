using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : TransformationBase
{
    private void Update()
    {
        transform.Rotate(Vector3.up * Speed * Time.deltaTime);
    }
}
