using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private const float _enemySpeedCoefficient = 0.9f;

    [SerializeField] private Player _player;
    [SerializeField] private Pursuer _enemy;

    private void Start()
    {
        float enemySpeed = _player.Speed * _enemySpeedCoefficient;
        _enemy.Initialize(_player, enemySpeed);
    }
}
