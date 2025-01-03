using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Gun))]
public class Enemy : PoolItem<Enemy>, ITouchable
{
    [SerializeField] private float _maxShootCooldown;

    private Coroutine _startShooting;
    private WaitForSeconds _delay;
    private EnemyMover _mover;
    private Gun _gun;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _startShooting = StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        StopCoroutine(StartShooting());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITouchable item))
            if (item is Player == false)
                DeadAction();
    }

    public IEnumerator StartShooting()
    {
        while (enabled)
        {
            yield return _delay;

            _gun.Shoot();
            SetShootingTimeDelay();
        }
    }

    private void Init()
    {
        _mover = GetComponent<EnemyMover>();
        _gun = GetComponent<Gun>();

        SetShootingTimeDelay();
    }

    private float GetRandom(float min, float max)
    {
        return Random.Range(min, max);
    }

    private void SetShootingTimeDelay()
    {
        _delay = new WaitForSeconds(GetRandom(0, _maxShootCooldown));
    }
}