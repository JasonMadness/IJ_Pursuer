using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pursuer _enemy;

    private float _speedDifference = 2f;

    private void Start()
    {
        float enemySpeed = _player.GetMovementSpeed() - _speedDifference;
        _enemy.Initialize(_player, enemySpeed);
    }
}
