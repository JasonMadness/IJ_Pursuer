using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 1f;

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

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) > _stopDistance)
        {
            _rigidbody.MovePosition(Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime));
        }

        transform.LookAt(_player.transform.position);
    }
}
