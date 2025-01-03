using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void ResetAngular()
    {
        _rigidBody.angularVelocity = 0;
    }

    private void Init()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector2(_speedX, _rigidBody.velocity.y - _speedY * Time.deltaTime);
    }
}