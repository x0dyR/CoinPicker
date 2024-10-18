using TMPro;
using UnityEngine;

public class WinTimer : MonoBehaviour
{
    private TMP_Text _counterText;

    private float _maxTime;
    private float _currentTime;

    private bool _isRunning;

    public float CurrentTime => _currentTime;

    private void Awake()
    {
        _counterText = GetComponentInChildren<TMP_Text>();
    }

    public void Initialize(float maxTime)
    {
        StartTimer();

        _maxTime = maxTime;
        _currentTime = maxTime;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _currentTime -= Time.deltaTime;

            UpdateTextTime();
        }
    }

    public void StopTimer() => _isRunning = false;

    public void ResetTime()
    {
        _currentTime = _maxTime;

        UpdateTextTime();

        StartTimer();
    }

    private void StartTimer() => _isRunning = true;

    private void UpdateTextTime() =>
        _counterText.text = "Seconds: " + _currentTime.ToString("0.00");
}
