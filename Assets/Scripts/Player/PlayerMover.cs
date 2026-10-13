using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 5f;

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
