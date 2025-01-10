using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxHight;

    private Rigidbody2D _rigidbody;
    private float _velocityX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (transform.position.y < _maxHight)
        {
            _velocityX = _rigidbody.velocity.x;
            _rigidbody.velocity = new Vector2(_velocityX, _jumpForce);
        }
    }
}