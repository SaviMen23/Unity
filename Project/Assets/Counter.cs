using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    public static event Action<int> CounterChanged;
    private bool _canWork = false;
    private int _counter = 0;

    private void OnEnable()
    {
        ClickProcessing.UserClicedOnMouse += StartCount;
    }

    private void OnDisable()
    {
        ClickProcessing.UserClicedOnMouse -= StartCount;
    }

    public void StartCount()
    {
        _canWork = _canWork == false;

        if (_canWork)
            StartCoroutine(UseTimer());
    }

    private IEnumerator UseTimer()
    {
        while (_canWork)
        {
            _counter++;
            CounterChanged?.Invoke(_counter);
            yield return new WaitForSecondsRealtime(_delay);
        }
    }
}
