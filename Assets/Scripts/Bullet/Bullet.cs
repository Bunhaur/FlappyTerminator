using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class Bullet : PoolItem<Bullet>, ITouchable
{
    [SerializeField] private float _lifeTime;

    private WaitForSeconds _delay;
    private Coroutine _timerWork;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _timerWork = StartCoroutine(Timer());
    }

    private void OnDisable()
    {
        SetDefault();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITouchable item))
        {
            DeadAction();
            StopCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return _delay;

        DeadAction();
    }

    private void Init()
    {
        _delay = new WaitForSeconds(_lifeTime);

        transform.SetParent(null);
    }

    private void SetDefault()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}