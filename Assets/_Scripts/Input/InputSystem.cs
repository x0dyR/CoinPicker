using UnityEngine;

public class InputSystem
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public Vector3 ReadInput()
        => new(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));
}
