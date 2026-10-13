using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerRotator _rotator;

    private void Update()
    {
        _mover.Move(_input.Direction);
        _rotator.Rotate(_input.Look);
    }
}