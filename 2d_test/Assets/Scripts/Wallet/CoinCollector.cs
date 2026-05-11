using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            coin.Give();
    }
}