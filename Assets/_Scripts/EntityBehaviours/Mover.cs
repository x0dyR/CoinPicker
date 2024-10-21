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

    public void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxisRaw(VerticalAxis)) >= DeadZone)
            _rigidbody.AddForce(_speed * Input.GetAxisRaw(VerticalAxis) * Camera.main.transform.forward);

        if (Mathf.Abs(Input.GetAxisRaw(HorizontalAxis)) >= DeadZone)
            _rigidbody.AddForce(_speed * Input.GetAxisRaw(HorizontalAxis) * Camera.main.transform.right);
    }
}
