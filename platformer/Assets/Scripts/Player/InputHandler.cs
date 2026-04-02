using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _JumpKey = KeyCode.Space;

    public event Action<float> AxisGot;
    public event Action KeyJumpPressed;

    private string Horizontal = nameof(Horizontal);
    private bool axisNotZero = true;

    private void Update()
    {
        CheckMove();
        CheckJump();
    }

    private void CheckMove()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction != 0)
            AxisGot?.Invoke(direction);

        if (axisNotZero && direction == 0)
            AxisGot?.Invoke(direction);

        axisNotZero = direction != 0;
    }

    private void CheckJump()
    {
        if(Input.GetKeyDown(_JumpKey))
            KeyJumpPressed?.Invoke();
    }
}
