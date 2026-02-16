using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickProcessing : MonoBehaviour
{
    public event Action UserClickedOnMouse;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UserClickedOnMouse?.Invoke();
        }
    }
}
