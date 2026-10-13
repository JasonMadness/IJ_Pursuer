using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    private Vector3 _direction;
    private Vector2 _look;

    public Vector3 Direction => _direction;
    public Vector2 Look => _look;

    private void Update()
    {
        float horizontal = Input.GetAxis(HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(VERTICAL_AXIS);
        _direction.Set(horizontal, 0f, vertical);

        _look.Set(Input.GetAxis(MOUSE_X), Input.GetAxis(MOUSE_Y));
    }
}