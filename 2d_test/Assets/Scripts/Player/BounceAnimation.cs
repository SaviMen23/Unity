using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    [SerializeField] private InputReader _inputHandler;
    [SerializeField] private Animator _animator;
    [SerializeField] private Bounce _bounce;
    [SerializeField] private string _variableJump;

    private int _hashJump;
    private bool _isGrounded = false;

    private void Awake()
    {
        _hashJump = Animator.StringToHash(_variableJump);
    }

    private void OnEnable()
    {
        _inputHandler.KeyJumpPressed += PlayAnimation;
        _bounce.IsGroundedChanged += SetGrounded;
    }

    private void OnDisable()
    {
        _inputHandler.KeyJumpPressed -= PlayAnimation;
        _bounce.IsGroundedChanged -= SetGrounded;
    }

    private void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    private void PlayAnimation()
    {
        if (_isGrounded)
            _animator.SetTrigger(_hashJump);
    }
}

