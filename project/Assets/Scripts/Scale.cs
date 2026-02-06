using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : TransformationBase
{
    private void Update()
    {
        transform.localScale += new Vector3(1f, 1f, 1f) * Speed * Time.deltaTime;
    }
}
