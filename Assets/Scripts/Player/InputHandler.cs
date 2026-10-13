using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    private Vector3 _direction;

    public Vector3 Direction => _direction;

    private void Update()
    {
        float horizontal = Input.GetAxis(HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(VERTICAL_AXIS);
        _direction.Set(horizontal, 0f, vertical);
    }
}
