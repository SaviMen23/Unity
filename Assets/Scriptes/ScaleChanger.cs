using UnityEngine;
using DG.Tweening;

public class ScaleChanger : MonoBehaviour 
{
    [SerializeField] private float _duration;
    [SerializeField] private float _deltaScale;

    private void Start()
    {
        Sequence animation = DOTween.Sequence();

        animation.Append(transform.DOScale(new Vector3(_deltaScale, _deltaScale,_deltaScale), _duration / 2))
            .Append(transform.DOScale(new Vector3(_deltaScale, _deltaScale, _deltaScale) * -1, _duration / 2))
            .SetRelative()
            .SetLoops(-1);
    }
}


