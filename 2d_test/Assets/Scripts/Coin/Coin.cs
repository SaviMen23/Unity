using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action CoinTook;

    public void Give() => CoinTook?.Invoke();

    public void Destroy() => Destroy(gameObject);
}
