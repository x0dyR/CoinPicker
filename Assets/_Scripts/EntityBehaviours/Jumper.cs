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

    public void ProcessJump()
        => _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

}
