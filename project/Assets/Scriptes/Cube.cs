using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> CubeDestroy;

    public float ChanceOfSeparation { get; private set; } = 1f;

    public void Destroy()
    {
         CubeDestroy?.Invoke(this);
    }

    public void SetChance(float chanceOfSeparation)
    {
        ChanceOfSeparation = chanceOfSeparation;
    }
}
