using UnityEngine;

public class Jumper
{
    private Rigidbody _rigidbody;

    private float _jumpForce;

    private bool _isJumping;

    public Jumper(Rigidbody rigidbody, float jumpForce)
    {
        _rigidbody = rigidbody;
        _jumpForce = jumpForce;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = true;
    }

    public void ProcessJump()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
        }
    }
}
