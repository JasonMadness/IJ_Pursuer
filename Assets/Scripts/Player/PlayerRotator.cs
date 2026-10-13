using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _sensitivity = 2f;

    private float _pitch;

    public void Rotate(Vector2 look)
    {
        float yaw = look.x * _sensitivity;
        transform.Rotate(Vector3.up, yaw, Space.World);

        _pitch -= look.y * _sensitivity;
        _pitch = Mathf.Clamp(_pitch, -89f, 89f);

        _camera.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }
}