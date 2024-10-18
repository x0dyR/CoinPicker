using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Character : MonoBehaviour
{
    public event Action<int> CoinPicked;

    [field: SerializeField] private float _speed;
    [field: SerializeField] private float _jumpForce;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private const float DeadZone = .1f;

    private bool _isJump;

    private int _coins;

    private Rigidbody _rigidbody;
    private SphereCollider _collider;

    private Camera _camera;

    private bool _isRunning;

    public void Initialize(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();

        _camera = Camera.main;

        StartCharacter();
    }

    public int Coins => _coins;

    public void ResetCharacter(Vector3 spawnPosition)
    {
        _coins = 0;
        CoinPicked?.Invoke(_coins);

        transform.position = spawnPosition;

        _rigidbody.isKinematic = true;
        _rigidbody.isKinematic = false;

        StartCharacter();
    }

    public void StopCharacter()
    {
        _isRunning = false;
        _rigidbody.isKinematic = true;
    }

    public void StartCharacter()
    {
        _isRunning = true;
        _rigidbody.isKinematic = false;
    }
    
    private void Update()
    {
        if (_isRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            if (Mathf.Abs(Input.GetAxisRaw(VerticalAxis)) >= DeadZone)
                _rigidbody.AddForce(_speed * Input.GetAxisRaw(VerticalAxis) * _camera.transform.forward);

            if (Mathf.Abs(Input.GetAxisRaw(HorizontalAxis)) >= DeadZone)
                _rigidbody.AddForce(_speed * Input.GetAxisRaw(HorizontalAxis) * _camera.transform.right);

            if (_isJump)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isJump = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            _coins += coin.Value;
            CoinPicked?.Invoke(_coins);

            coin.gameObject.SetActive(false);
        }
    }
}
