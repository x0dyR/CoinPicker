using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [field: SerializeField] private List<Coin> _coins;

    [field: SerializeField] private Character _character;
    [field: SerializeField] private Transform _characterSpawnPoint;

    [field: SerializeField] private WinTimer _winTimer;

    [field: SerializeField] private float _winTime;

    [field: SerializeField] private GameObject _blackScreen;
    [field: SerializeField] private TMP_Text _winText;
    [field: SerializeField] private TMP_Text _loseText;

    [field:SerializeField]private int _currentCoinsCount;    

    private void Awake()
    {
        _character.Initialize(_characterSpawnPoint.position);
        _character.CoinPicked += OnCoinPicked;
        
        _currentCoinsCount = 0;

        _winTimer.Initialize(_winTime);
    }

    private void OnCoinPicked(int value)
    {
        _currentCoinsCount++;
    }

    private void Update()
    {
        if (_currentCoinsCount == _coins.Count)
        {
            _winTimer.StopTimer();
            _character.StopCharacter();

            _blackScreen.gameObject.SetActive(true);

            if (_currentCoinsCount >= _coins.Count)
                _winText.gameObject.SetActive(true);
        }
        else if(_winTimer.CurrentTime <= 0.0f)
        {
            _winTimer.StopTimer();
            _character.StopCharacter();

            _blackScreen.gameObject.SetActive(true);
                        
            if (_currentCoinsCount < _coins.Count)
                _loseText.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (var coin in _coins)
                coin.gameObject.SetActive(true);

            _character.ResetCharacter(_characterSpawnPoint.position);

            _currentCoinsCount = 0;

            _winTimer.ResetTime();

            _blackScreen.gameObject.SetActive(false);
            _loseText.gameObject.SetActive(false);
            _winText.gameObject.SetActive(false);
        }
    }
}
