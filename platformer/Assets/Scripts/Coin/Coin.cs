using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action CoinTook;

    public void Take() => CoinTook?.Invoke();

    public void Destroy() => Destroy(gameObject);
}
