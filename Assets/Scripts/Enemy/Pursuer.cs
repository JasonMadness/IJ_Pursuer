using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 2.5f;

    private float _speed;
    private Player _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Player player, float speed)
    {
        _player = player;
        _speed = speed;
    }

    private void Update()
    {
        transform.LookAt(_player.transform.position);
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = _player.transform.position - transform.position;
        toPlayer.y = 0f;

        if (toPlayer.sqrMagnitude > _stopDistance * _stopDistance)
        {
            Vector3 direction = toPlayer.normalized;
            float vertical = _rigidbody.velocity.y;            
            _rigidbody.velocity = direction * _speed + Vector3.up * vertical;
        }
    }
}
