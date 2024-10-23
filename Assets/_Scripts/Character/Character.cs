using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private const float DeadZone = .1f;

    private bool _isJump;
    private Jumper _jumper;

    private Rigidbody _rigidbody;
    private SphereCollider _collider;

    private Camera _camera;

    private InputSystem _input;

    private bool _isRunning;
    private Mover _mover;

    private Vector3 _moveDirection;

    private int _coins;
    private Wallet _wallet;
    private CoinCollector _coinCollector;

    public int Coins => _coins;

    public Wallet Wallet => _wallet;

    public void Initialize(Vector3 spawnPosition)
    {
        _wallet = new Wallet();

        transform.position = spawnPosition;

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();

        _input = new InputSystem();

        _mover = new Mover(_rigidbody, _speed);
        _jumper = new Jumper(_rigidbody, _jumpForce);

        _coinCollector = new CoinCollector(_wallet);

        _camera = Camera.main;

        StartCharacter();
    }

    public void ResetCharacter(Vector3 spawnPosition)
    {
        _wallet.ResetWallet();

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
            _moveDirection = _input.ReadInput();

            if (_input.ReadInput().magnitude > Vector3.zero.magnitude)
                _moveDirection = (_camera.transform.forward * _moveDirection.z) + (_camera.transform.right * _moveDirection.x); 
            
            _jumper.Update();
        }
    }

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            _jumper.ProcessJump();
            _mover.MoveEntity(_moveDirection);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Coin coin))
            _coinCollector.CollectCoin(coin);
    }
}

