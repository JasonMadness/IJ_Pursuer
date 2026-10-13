using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;

    public void Move(Vector3 direction)
    {
        Vector3 moveDirection = transform.TransformDirection(direction);
        _characterController.Move(moveDirection * _speed * Time.deltaTime);
    }
}
