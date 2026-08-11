using UnityEngine;
using DG.Tweening;

public class RotateChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _degrees;

    private void Start()
    {
        Sequence animation = DOTween.Sequence();

        animation.Append(transform.DORotate(new Vector3(0f, _degrees, 0f), _duration, RotateMode.FastBeyond360))
            .SetRelative()
            .SetLoops(-1);
    }
}