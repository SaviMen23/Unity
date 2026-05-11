using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;
    [SerializeField] private float _minDelay = 2f;
    [SerializeField] private float _maxDelay = 5f;

    private int _min = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
            if (target.IsRepainted == false)
                StartCoroutine(RepaintWithDelay(target));
    }

    private void OnValidate()
    {
        if (_minDelay > _maxDelay)
            _minDelay = _maxDelay;
    }

    private IEnumerator RepaintWithDelay(Target target)
    {
        target.BeRepainted();
        target.GetComponent<Renderer>().material.color = _colors[Random.Range(_min, _colors.Count)];
        yield return new WaitForSecondsRealtime(Random.Range(_minDelay, _maxDelay));
        target.Remove();
    }
}
