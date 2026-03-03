using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Target : MonoBehaviour
{
    public event Action<Target> TargetPooled;

    private bool _isRapainted = false;
    private Renderer _prefabRenderer;
    private Rigidbody _rigidbody;

    public bool IsRepainted { get { return _isRapainted; } }

    private void Awake()
    {
        _prefabRenderer =  this.GetComponent<Renderer>();
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    public void Remove()
    {
        TargetPooled?.Invoke(this);
    }

    public void Clear(Color prefabColor)
    {
        _isRapainted = false;
        _prefabRenderer.material.color = prefabColor;
        _rigidbody.velocity = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
    }

    public void BeRepainted()
    {
        _isRapainted = true;
    }
}
