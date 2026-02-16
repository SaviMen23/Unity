using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += Show;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= Show;
    }

    private void Show(int counter)
    {
        Debug.Log(counter);
    }
}
