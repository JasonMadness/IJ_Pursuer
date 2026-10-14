using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private Vector3 _direction;
    private Vector2 _look;

    public Vector3 Direction => _direction;
    public Vector2 Look => _look;

    private void Update()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        float vertical = Input.GetAxis(VerticalAxis);
        _direction.Set(horizontal, 0f, vertical);
        _look.Set(Input.GetAxis(MouseX), Input.GetAxis(MouseY));
    }
}