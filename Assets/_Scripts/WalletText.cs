using TMPro;
using UnityEngine;

public class WalletText : MonoBehaviour
{
    [field: SerializeField] private Character _character;
    
    private TMP_Text _coinsText;

    private void Awake()
    {
        _coinsText = GetComponentInChildren<TMP_Text>();
    
        _character.CoinPicked += OnCoinPicked;
    }

    private void OnCoinPicked(int value)
    {
        _coinsText.text = "Coins: " + value.ToString();
    }
}
