using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action CoinTaked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wallet wallet = collision.GetComponentInChildren<Wallet>();

        if (wallet != null)
        {
            wallet.TakeCoin();
            CoinTaked?.Invoke();
        }
    }

    public void Destroy() => Destroy(gameObject);
}
