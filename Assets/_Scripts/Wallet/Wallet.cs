using System;

public class Wallet
{
    public event Action<int> CoinPicked;

    private int _coins;

    public Wallet()
    {
        _coins = 0;
    }

    public void AddCoins(int value)
    {
        _coins += value;

        CoinPicked?.Invoke(_coins);
    }

    public void ResetWallet()
    {
        _coins = 0;

        CoinPicked?.Invoke(_coins);
    }
}
