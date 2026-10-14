using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 2.5f;
    [SerializeField] private float _groundCheckDistance = 1.2f;
    [SerializeField] private float _maxStepHeight = 0.3f;
    [SerializeField] private float _rayLength = 0.7f;
    [SerializeField] private float _footOffset = 0.1f;

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

            bool canStep = CanStep(direction, out float stepHeight);

            if (canStep)
            {
                _rigidbody.velocity = direction * _speed + Vector3.up * vertical;

                if (stepHeight > 0f)
                    _rigidbody.position += Vector3.up * stepHeight;
            }
            else
            {
                _rigidbody.velocity = Vector3.up * vertical;
            }
        }
    }

    private Vector3 GetGroundNormal()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _groundCheckDistance))
            return hit.normal;

        return Vector3.up;
    }

    private bool CanStep(Vector3 direction, out float stepHeight)
    {
        stepHeight = 0f;

        Vector3 lowerOrigin = transform.position + Vector3.up * _footOffset;
        Vector3 upperOrigin = lowerOrigin + Vector3.up * _maxStepHeight;
        bool lowerHit = Physics.Raycast(lowerOrigin, direction, out RaycastHit lowerInfo, _rayLength);
        bool upperHit = Physics.Raycast(upperOrigin, direction, out RaycastHit upperInfo, _rayLength);

        if (lowerHit == false && upperHit == false)
            return true;

        stepHeight = lowerInfo.point.y - transform.position.y;
        return stepHeight <= _maxStepHeight;
    }
}
