using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner
{
    private Coin _coinPrefab;
    private List<Transform> _coinsSpawnPoints;

    public List<Coin> Coins { get; private set; }

    public CoinSpawner(Coin coinPrefab, List<Transform> coinsSpawnPoints)
    {
        _coinPrefab = coinPrefab;
        _coinsSpawnPoints = coinsSpawnPoints;
        Coins = new List<Coin>();
    }

    public void SpawnCoins()
    {
        foreach (var transform in _coinsSpawnPoints)
        {
            Coin coin = Object.Instantiate(_coinPrefab, transform.position, Quaternion.identity, transform);

            coin.RandomizeValue();

            Coins.Add(coin);
        }
    }

    public void DestoyCoins()
    {
        for (int i = 0; i < Coins.Count; i++)
        {
            if (Coins[i] != null)
                Object.Destroy(Coins[i].gameObject);
        }

        Coins.Clear();
    }
}
