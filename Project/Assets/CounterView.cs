using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    private void OnEnable()
    {
        Counter.CounterChanged += Show;
    }

    private void OnDisable()
    {
        Counter.CounterChanged -= Show;
    }

    private void Show(int counter)
    {
        Debug.Log(counter);
    }
}
