using System;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private TriggerZone _triggerZone;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delta;

    private float _targetVolume = 0f;
    private bool _canWork = false;

    private void Start()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _triggerZone.TriggerWorked += Toggle;
    }

    private void OnDisable()
    {
        _triggerZone.TriggerWorked -= Toggle;
    }

    private void Toggle(bool isTurnOn, Collider other)
    {
        if (isTurnOn)
        {
            if (other.GetComponent<Movement>() != null)
            {
                _canWork = true;
                _targetVolume = 1f;
            }
        }
        else
        {
            if (other.GetComponent<Movement>() != null)
                _targetVolume = 0f;
        }
    }

    private void Update()
    {
        if (_canWork)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _delta * Time.deltaTime);

        _canWork = _audioSource.volume > 0f;
    }
}