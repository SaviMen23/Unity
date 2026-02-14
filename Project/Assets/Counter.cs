using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static event Action CounterChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CounterChanged?.Invoke();
        }
    }
}
