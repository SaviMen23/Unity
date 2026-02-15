using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickProcessing : MonoBehaviour
{
    public static event Action UserClicedOnMouse;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UserClicedOnMouse?.Invoke();
        }
    }
}
