using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _groundCheckDistance = 1.2f;

    private float _gravity = Physics.gravity.y;
    private float _groundedStick = -2f;
    private float _verticalVelocity;

    public float Speed => _speed;

    public void Move(Vector3 direction)
    {
        if (_characterController.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = _groundedStick;

        _verticalVelocity += _gravity * Time.deltaTime;

        Vector3 worldDirection = transform.TransformDirection(direction);
        Vector3 normal = GetGroundNormal();
        worldDirection = Vector3.ProjectOnPlane(worldDirection, normal).normalized;

        Vector3 velocity = worldDirection * _speed + Vector3.up * _verticalVelocity;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private Vector3 GetGroundNormal()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _groundCheckDistance))
            return hit.normal;
        else
            return Vector3.up;
    }
}
