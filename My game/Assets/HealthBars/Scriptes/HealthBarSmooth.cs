using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class HealthBarSmooth : HealthBar
{
    [SerializeField, Min(0)] private float _delta;
    [SerializeField, Min(0)] private float _delay;

    private WaitForSecondsRealtime _delayForCoroutine;

    private void Awake()
    {
        _delayForCoroutine = new WaitForSecondsRealtime(_delay);
    }

    protected override void ChangeBar(int currentHeanthPoints)
    {
        StartCoroutine(MoveHealthBarWithDelay(currentHeanthPoints));
    }

    private IEnumerator MoveHealthBarWithDelay(int currentHealthPoints)
    {
        while(Slider.value != currentHealthPoints)
        {
            Slider.value = Mathf.Lerp(Slider.value, currentHealthPoints, _delta);
            yield return _delayForCoroutine;
        }
    }
}
