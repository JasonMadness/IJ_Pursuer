using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private PlayerMover _mover;

    private void Update()
    {
        _mover.Move(_input.Direction);
    }
}
