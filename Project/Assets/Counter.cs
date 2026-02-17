using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private ClickProcessing _clickProcessing;

    public event Action<int> CounterChanged;
    private bool _canWork = false;
    private int _counter = 0;

    private void OnEnable()
    {
        _clickProcessing.UserClickedOnMouse += StartCount;
    }

    private void OnDisable()
    {
        _clickProcessing.UserClickedOnMouse -= StartCount;
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
