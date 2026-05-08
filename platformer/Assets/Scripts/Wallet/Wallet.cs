using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<int> WalletChanged;

    private int _current = 0;

    public void TakeCoin() => WalletChanged.Invoke(++_current);
}
