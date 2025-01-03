using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody;

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
        _rigidBody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Move()
    {
        _rigidBody.velocity = Vector3.left * _speed;
    }
}