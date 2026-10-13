using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pursuer _enemy;

    private void Start()
    {
        _enemy.Initialize(_player);
    }
}
