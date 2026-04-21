using UnityEngine;

public class TakeCoinAnimation : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _variableName;

    private int _hash;

    private void Awake()
    {
        _hash = Animator.StringToHash(_variableName);
    }

    private void OnEnable()
    {
        _coin.CoinTook += Play;
    }

    private void OnDisable()
    {
        _coin.CoinTook -= Play;
    }

    private void Play()
    {
        _animator.SetTrigger(_hash);
    }
}
