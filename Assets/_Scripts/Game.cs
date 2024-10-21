using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _coinsSpawnPoints;

    [SerializeField] private Character _character;
    [SerializeField] private Transform _characterSpawnPoint;

    [SerializeField] private Timer _timer;

    [SerializeField] private float _winTime;

    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private TMP_Text _loseText;

    [SerializeField] private int _currentCoinsCount;

    private CoinSpawner _coinSpawner;

    public int CoinsCount => _coinsSpawnPoints.Count;

    private void Awake()
    {
        _character.Initialize(_characterSpawnPoint.position);
        _character.Wallet.CoinPicked += OnCoinPicked;

        _timer.Initialize(_winTime);

        _coinSpawner = new(_coinPrefab, _coinsSpawnPoints);
        _coinSpawner.SpawnCoins();
    }

    private void OnCoinPicked(int value)
    {
        if (value > 0)
            _currentCoinsCount++;
    }

    private void Update()
    {
        DetermineCondition();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        _character.ResetCharacter(_characterSpawnPoint.position);

        _currentCoinsCount = 0;

        ResetCoins();

        _timer.ResetTime();

        HideConditionsScreen();
    }

    private void ResetCoins()
    {
        _coinSpawner.DestoyCoins();
        _coinSpawner.SpawnCoins();
    }

    private void HideConditionsScreen()
    {
        _blackScreen.SetActive(false);
        _loseText.gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
    }

    private void DetermineCondition()
    {
        if (_currentCoinsCount == CoinsCount)
        {
            Win();
        }
        else if (_timer.CurrentTime <= 0.0f)
        {
            Lose();
        }
    }

    private void Lose()
    {
        StopEntities();

        _blackScreen.SetActive(true);

        if (_currentCoinsCount < CoinsCount)
            _loseText.gameObject.SetActive(true);
    }

    private void Win()
    {
        StopEntities();

        _blackScreen.SetActive(true);

        if (_currentCoinsCount >= CoinsCount)
            _winText.gameObject.SetActive(true);
    }

    private void StopEntities()
    {
        _timer.StopTimer();
        _character.StopCharacter();
    }
}
