using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public void Move(Vector3 direction)
    {
        transform.position += direction;
    }
}
