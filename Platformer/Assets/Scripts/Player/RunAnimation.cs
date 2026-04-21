using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RunAnimation : MonoBehaviour
{
    [SerializeField] private InputReader _inputHandler;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _variableRun;

    private int _hashRun;
    private int currentDirection = 1;

    private void Awake()
    {
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
        if (direction != 0 && currentDirection != direction)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            currentDirection = (int)direction;
        }

        _animator.SetBool(_hashRun, direction != 0);
    }
}
