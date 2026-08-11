using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private Color _firstColor;
    [SerializeField] private Color _secondColor;

    private void Start()
    {
        Sequence animation = DOTween.Sequence();

        animation.Append(_renderer.material.DOColor(_secondColor, _duration / 2))
            .AppendInterval(_delay)
            .Append(_renderer.material.DOColor(_firstColor, _duration / 2))
            .AppendInterval(_delay)
            .SetRelative()
            .SetLoops(-1);
    }
}

