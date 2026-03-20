using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public event Action<bool, Collider> TriggerWorked;

    private void OnTriggerEnter(Collider other)
    {
        TriggerWorked?.Invoke(true, other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerWorked?.Invoke(false, other);
    }
}
