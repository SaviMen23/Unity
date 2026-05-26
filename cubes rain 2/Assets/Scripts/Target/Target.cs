using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Target : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;
    [SerializeField, Min(0)] private float _minDelay = 2f;
    [SerializeField, Min(0)] private float _maxDelay = 5f;

    public event Action<Target> TargetPooled;

    private int _min = 0;
    private bool _isRepainted = false;

    private void OnValidate()
    {
        if (_minDelay > _maxDelay)
            _minDelay = _maxDelay;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform target))
            if (_isRepainted == false)
                StartCoroutine(RepaintWithDelay());
    }

    public void Remove()
    {
        TargetPooled?.Invoke(this);
    }

    public void Clear(Color prefabColor)
    {
        _isRepainted = false;
        this.GetComponent<Renderer>().material.color = prefabColor;
    }

    public void BecomeRepainted()
    {
        _isRepainted = true;
    }

    private IEnumerator RepaintWithDelay()
    {
        BecomeRepainted();
        GetComponent<Renderer>().material.color = _colors[Random.Range(_min, _colors.Count)];

        yield return new WaitForSecondsRealtime(Random.Range(_minDelay, _maxDelay));

        Remove();
    }
}
