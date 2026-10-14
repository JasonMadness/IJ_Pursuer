using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 2.5f;
    [SerializeField] private float _groundCheckDistance = 1.2f;

    private Player _player;
    private Rigidbody _rigidbody;
    private float _speed;

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

            Vector3 normal = GetGroundNormal();
            direction = Vector3.ProjectOnPlane(direction, normal);
            direction.y = 0f;
            float vertical = _rigidbody.velocity.y;
            _rigidbody.velocity = direction * _speed + Vector3.up * vertical;
        }
    }

    private Vector3 GetGroundNormal()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _groundCheckDistance))
            return hit.normal;

        return Vector3.up;
    }
}
