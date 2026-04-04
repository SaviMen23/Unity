using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _JumpKey = KeyCode.Space;

    public event Action<float> AxisGot;
    public event Action KeyJumpPressed;

    private string _horizontal = "Horizontal";
    private bool axisNotZero = true;

    private void Update()
    {
        CheckMove();
        CheckJump();
    }

    private void CheckMove()
    {
        float direction = Input.GetAxis(_horizontal);

        if (direction != 0)
            AxisGot?.Invoke(direction);
    }

    private void CheckJump()
    {
        if(Input.GetKeyDown(_JumpKey))
            KeyJumpPressed?.Invoke();
    }
}
