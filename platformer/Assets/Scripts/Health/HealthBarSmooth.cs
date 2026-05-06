using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class HealthBarSmooth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _characterHealth;
    [SerializeField, Min(0)] private float _delta;
    [SerializeField, Min(0)] private float _delay;

    private WaitForSecondsRealtime _delayForCoroutine;

    private void Awake()
    {
        _delayForCoroutine = new WaitForSecondsRealtime(_delay);
    }

    private void Start()
    {
        _slider.maxValue = _characterHealth.MaxHealth;
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _characterHealth.HealthChanged += ChangeBar;
    }

    private void OnDisable()
    {
        _characterHealth.HealthChanged -= ChangeBar;
    }

    private void ChangeBar(int currentHeanthPoints)
    {
        StartCoroutine(MoveHealthBarWithDelay(currentHeanthPoints));
    }

    private IEnumerator MoveHealthBarWithDelay(int currentHealthPoints)
    {
        while(_slider.value != currentHealthPoints)
        {
            _slider.value = Mathf.Lerp(_slider.value, currentHealthPoints, _delta);
            yield return _delayForCoroutine;
        }
    }
}
