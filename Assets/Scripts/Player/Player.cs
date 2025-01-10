using System;
using UnityEngine;

[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(HandlerInput))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Gun))]
public class Player : MonoBehaviour, ITouchable
{
    private PlayerRotation _rotation;
    private PlayerMover _playerMover;
    private Vector2 _defaultPosition;
    private PlayerJumper _jumper;
    private HandlerInput _input;
    private Gun _gun;

    public event Action Dead;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _input.FireButtonPushed += Shoot;
        _input.JumpButtonPushed += Jump;
    }

    private void OnDisable()
    {
        _input.FireButtonPushed -= Shoot;
        _input.JumpButtonPushed -= Jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITouchable item))
        {
            Dead?.Invoke();
            _input.SetCanInput(false);
        }
    }

    public void Reset()
    {
        transform.position = _defaultPosition;
        _playerMover.ResetVelocity();
        _playerMover.ResetAngular();
        _input.SetCanInput(true);
    }

    private void Init()
    {
        _playerMover = GetComponent<PlayerMover>();
        _rotation = GetComponent<PlayerRotation>();
        _jumper = GetComponent<PlayerJumper>();
        _input = GetComponent<HandlerInput>();
        _gun = GetComponent<Gun>();

        _defaultPosition = transform.position;
    }

    private void Jump()
    {
        _playerMover.ResetAngular();
        _rotation.SetMaxRotation();
        _jumper.Jump();
    }

    private void Shoot()
    {
        _gun.Shoot();
    }
}