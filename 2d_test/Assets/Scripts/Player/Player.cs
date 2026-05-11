using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Bounce _bounce;

    private void Update()
    {
        if (_inputReader != null)
            _inputReader.Read();

        if (_inputReader != null)
            _bounce.UpdateStateIsGrounded();
    }
}

