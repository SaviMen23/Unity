using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]

public class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] private float _minDelayBeforeExplode;
    [SerializeField, Min(0)] private float _maxDelayBeforeExplode;
    [SerializeField, Min(0)] private float _explodeRadius;
    [SerializeField, Min(0)] private float _forceExplode;

    public event Action<Bomb> BombPooled;

    private Renderer _renderer;
    private float _timeBeforeExplode;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Work()
    {
        _timeBeforeExplode = Random.Range(_minDelayBeforeExplode, _maxDelayBeforeExplode);
        StartCoroutine(CountDawn());
    }

    private IEnumerator CountDawn()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= _timeBeforeExplode)
        {
            elapsedTime += Time.deltaTime;
            float currentPercentComplete = elapsedTime / _timeBeforeExplode;
            Color current = _renderer.material.color;
            current.a = Mathf.Lerp(1f, 0f, currentPercentComplete);
            _renderer.material.color = current;

            yield return null;
        }

        Explode();
        Remove();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explodeRadius);

        foreach (Collider collider in colliders)
            if (collider.TryGetComponent(out Rigidbody component))
                component.AddExplosionForce(_forceExplode, transform.position, _explodeRadius);
    }

    private void Remove()
    {
      BombPooled?.Invoke(this);
    }
}