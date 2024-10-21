using UnityEngine;

public class CoinCollector
{
    private Wallet _wallet;
    public CoinCollector(Wallet wallet)
    {
        _wallet = wallet;
    }

    public void CollectCoin(Coin coin)
    {
        _wallet.AddCoins(coin.Value);

        Object.Destroy(coin.gameObject);
    }
}
