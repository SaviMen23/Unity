using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSmooth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _characterHealth;
    [SerializeField] private float _duration;

    private void Start()
    {
        _slider.maxValue = _characterHealth.Max;
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

    private void ChangeBar(int currentHealthPoints)
    {
        StartCoroutine(MoveHealthBarWithDelay(currentHealthPoints));
    }

    private IEnumerator MoveHealthBarWithDelay(int currentHealthPoints)
    {
        float startValue = _slider.value;
        float timer = 0f;

        while (timer < _duration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / _duration;
            _slider.value = Mathf.Lerp(startValue, currentHealthPoints, normalizedTime);

            yield return null;
        }

        _slider.value = currentHealthPoints;
    }
}
