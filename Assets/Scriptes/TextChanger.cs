using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    [SerializeField] private Text _text;

    private void Start()
    {
        Sequence mainAnimation = DOTween.Sequence();
        Tween replaceTween = _text.DOText(" Добавлен", _duration).SetRelative();

        mainAnimation
            .Append(_text.DOText("Заменен", _duration)).AppendInterval(_delay)
            .Append(replaceTween).AppendInterval(_delay)
            .Append(_text.DOText("Взломан", _duration, true, ScrambleMode.All)).AppendInterval(_delay)
            .SetLoops(-1);
    }
}
