using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Target : MonoBehaviour
{
    public event Action<Target> TargetPooled;
    public bool IsRepainted { get { return _isRapainted; } }

    private bool _isRapainted = false;

    public void Remove()
    {
        TargetPooled?.Invoke(this);
    }

    public void Clear(Color prefabColor)
    {
        _isRapainted = false;
        this.GetComponent<Renderer>().material.color = prefabColor;
    }

    public void BeRepainted()
    {
        _isRapainted = true;
    }
}
