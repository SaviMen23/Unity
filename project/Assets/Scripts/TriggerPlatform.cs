using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public event Action<Target> TargetCollisionEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
            if (target.IsRepainted == false)
                TargetCollisionEnter?.Invoke(target);   
    }
}
