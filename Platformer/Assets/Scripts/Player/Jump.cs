using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputReader _inputHandler;
    [SerializeField] private float _force;
    [SerializeField] private float _overlapRadius = 0.2f;
    [SerializeField] private LayerMask _layerMask;

    public event Action<bool> IsGroundedChanged;

    private Rigidbody2D _parentRigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        if (transform.parent != null)
            _parentRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool target = _isGrounded;
        _isGrounded = Physics2D.OverlapCircle(transform.position, _overlapRadius, _layerMask);

        if(target != _isGrounded)
            IsGroundedChanged?.Invoke(_isGrounded);
    }

    private void OnEnable()
    {
        _inputHandler.KeyJumpPressed += TryJump;
    }

    private void OnDisable()
    {
        _inputHandler.KeyJumpPressed -= TryJump;
    }

    private void TryJump()
    {
        if (_isGrounded)
            _parentRigidbody?.AddForce(Vector2.up * _force);
    }
}

