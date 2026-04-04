using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.WalletChanged += Show;
    }

    private void OnDisable()
    {
        _wallet.WalletChanged -= Show;
    }

    private void Show(int wallet) => Debug.Log($"кошелек: {wallet}");
}
