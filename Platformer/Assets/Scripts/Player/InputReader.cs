using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _JumpKey = KeyCode.Space;

    public event Action<float> AxisGot;
    public event Action KeyJumpPressed;

    private string _horizontal = "Horizontal";
    private bool _canSand = true;

    private void Update()
    {
        CheckMove();
        CheckJump();
    }

    private void CheckMove()
    {
        float direction = Input.GetAxisRaw(_horizontal);

        if (direction != 0)
            AxisGot?.Invoke(direction);

        if (_canSand && direction == 0)
            AxisGot?.Invoke(direction);

        _canSand = direction != 0;
    }

    private void CheckJump()
    {
        if(Input.GetKeyDown(_JumpKey))
            KeyJumpPressed?.Invoke();
    }
}
