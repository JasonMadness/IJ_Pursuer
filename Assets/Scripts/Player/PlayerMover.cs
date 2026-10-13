using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;

    private float _gravity = Physics.gravity.y;
    private float _groundedStick = -2f;
    private float _verticalVelocity;

    public void Move(Vector3 direction)
    {
        if (_characterController.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = _groundedStick;

        _verticalVelocity += _gravity * Time.deltaTime;

        Vector3 moveDirection = transform.TransformDirection(direction);
        Vector3 velocity = moveDirection * _speed + Vector3.up * _verticalVelocity;

        _characterController.Move(velocity * Time.deltaTime);
    }
}