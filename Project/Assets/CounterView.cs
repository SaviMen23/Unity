using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private int _counter = 0;
    private bool _canWork = false;
    private bool _isRunning = true;

    private void OnEnable()
    {
        Counter.CounterChanged += Changed;
    }

    private void OnDisable()
    {
        Counter.CounterChanged -= Changed;
    }

    private void Changed()
    {
        _canWork = _canWork == false;

        if (_canWork)
            _isRunning = false;
    }

    private void Update()
    {
        if(_canWork && _isRunning == false)
        {
            _isRunning = true;
            StartCoroutine(UseTimer());
        }
    }

    private IEnumerator UseTimer()
    {
        while (_canWork)
        {
            Debug.Log(++_counter);
            yield return new WaitForSecondsRealtime(_delay);
        }
    }
}
