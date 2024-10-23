using UnityEngine;

public class Mover
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private const float DeadZone = .1f;

    private Rigidbody _rigidbody;

    private float _speed;

    public Mover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void MoveEntity(Vector3 direction)
    {
        if (direction.sqrMagnitude >= DeadZone * DeadZone)
            _rigidbody.AddForce(_speed * direction);
    }
}
