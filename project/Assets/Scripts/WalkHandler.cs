using UnityEngine;

public class WalkHandler : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _parameterName;

    private int _hash;

    private void Awake()
    {
        _hash = Animator.StringToHash(_parameterName);
        _animator.SetBool(_hash, false);
    }

    private void OnEnable()
    {
        _movement.BodyWent += SetAnimationWalk;
    }

    private void OnDisable()
    {
        _movement.BodyWent -= SetAnimationWalk;
    }

    private void SetAnimationWalk(bool isWalk) 
    {
        _animator.SetBool(_hash, isWalk);
    }
}
