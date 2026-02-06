using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : TransformationBase
{
    private void Update()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime);
    }
}
