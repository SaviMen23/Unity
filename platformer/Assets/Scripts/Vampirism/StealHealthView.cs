using System;
using UnityEngine;
using UnityEngine.UI;

public class StealHealthView : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private StealerHealth _stealerHealth;
    [SerializeField] private Image _fillImage;
    [SerializeField] private Color _durationColor;
    [SerializeField] private Color _reloadColor;

    private bool _canChangeBar = false;
    private int _currentSign = 0;

    private void OnEnable()
    {
        _stealerHealth.AbilityWork += DoDuration;
    }

    private void OnDisable()
    {
        _stealerHealth.AbilityWork -= DoDuration;
    }

    public void Initialize()
    {
        _bar.maxValue = _stealerHealth.AbilityDurationTime;
        _bar.value = _stealerHealth.AbilityDurationTime;
        _fillImage.color = _durationColor;
    }

    public void DoDuration()
    {
        _bar.maxValue = _stealerHealth.AbilityDurationTime;
        _bar.value = _stealerHealth.AbilityDurationTime;
        _currentSign = -1;
        _canChangeBar = true;
    }

    public void Renew()
    {
        if (_canChangeBar)
            _bar.value += Time.deltaTime * Math.Sign(_currentSign);

        if (_bar.value == _bar.maxValue)
        {
            _canChangeBar = false;
            _fillImage.color = _durationColor;
        }

        if (_bar.value == _bar.minValue)
        {
            _fillImage.color = _reloadColor;
            DoReload();
        }
    }

    private void DoReload()
    {
        _bar.maxValue = _stealerHealth.AbilityReloadTime;
        _currentSign = 1;
        _canChangeBar = true;
    }
}



