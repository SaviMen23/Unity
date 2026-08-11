using UnityEngine;
using DG.Tweening;

public class MoveChanger : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _offset;

    private void Start()
    {
        Sequence animation = DOTween.Sequence();

        animation.Append(transform.DOMoveY(_offset, _duration / 2))
            .Append(transform.DOMoveY(-_offset, _duration / 2))
            .SetRelative()
            .SetLoops(-1);
    }
}
