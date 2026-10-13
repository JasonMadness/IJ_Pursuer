using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _stopDistance = 2.5f;

    private Player _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) > _stopDistance)
        {
            Vector3 direction = (_player.transform.position - transform.position);
            direction.Normalize();
            float vertical = _rigidbody.velocity.y;            
            _rigidbody.velocity = direction * _speed + Vector3.up * vertical;
        }

        transform.LookAt(_player.transform.position);
    }
}
