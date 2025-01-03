using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Direction _direction;

    private Rigidbody2D _rigidBody;
    private Vector2 _currentDirection;

    private enum Direction
    {
        Forward,
        Backward
    }

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Init()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        SetDirection();

        _rigidBody.velocity = _currentDirection * _speed;
    }

    private void SetDirection()
    {
        switch (_direction)
        {
            case Direction.Forward:
                _currentDirection = transform.right;
                break;
            case Direction.Backward:
                _currentDirection = -transform.right;
                break;
        }
    }
}