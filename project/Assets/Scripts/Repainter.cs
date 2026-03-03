using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Repainter : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private TriggerPlatform[] _platforms;
    [SerializeField] private float _minDelay = 2f;
    [SerializeField] private float _maxDelay = 5f;

    private int _minIndexColor = 0;

    private void OnValidate()
    {
        if (_minDelay > _maxDelay)
            _minDelay = _maxDelay;
    }

    private void OnEnable()
    {
        foreach (var platform in _platforms)
            platform.TargetCollisionEnter += Repaint;
    }

    private void OnDisable()
    {
        foreach (var platform in _platforms)
            platform.TargetCollisionEnter -= Repaint;
    }

    private void Repaint(Target target)
    {
        StartCoroutine(RepaintWithDelay(target));
    }

    private IEnumerator RepaintWithDelay(Target target)
    {
        target.BeRepainted();
        target.GetComponent<Renderer>().material.color = _colors[Random.Range(_minIndexColor, _colors.Length)];
        yield return new WaitForSecondsRealtime(Random.Range(_minDelay, _maxDelay));
        target.Remove();
    }
}
