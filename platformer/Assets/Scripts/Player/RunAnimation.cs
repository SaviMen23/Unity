using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RunAnimation : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _variableRun;

    private int _hashRun;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hashRun = Animator.StringToHash(_variableRun);
    }

    private void OnEnable()
    {
        _inputHandler.AxisGot += SetAnimation;
    }

    private void OnDisable()
    {
        _inputHandler.AxisGot -= SetAnimation;
    }

    private void SetAnimation(float direction)
    {
        if (direction != 0)
            _spriteRenderer.flipX = direction < 0;

        _animator.SetBool(_hashRun, direction != 0);
    }
}
