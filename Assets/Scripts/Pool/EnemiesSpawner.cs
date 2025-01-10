using System.Collections;
using UnityEngine;

public class EnemiesSpawner : Spawner<Enemy>
{
    [SerializeField] private float _maxSpawnValueY;
    [SerializeField] private float _minSpawnValueY;

    private Vector3 _newSpawnPosition;
    private EnemyPool _enemyPool;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartTimeOutWork = StartCoroutine(StartTimeOut());
    }

    public void Reset()
    {
        _enemyPool.Reset();
        OffActiveObjects();
    }

    protected override void Init()
    {
        base.Init();

        _enemyPool = Pool as EnemyPool;
    }

    private IEnumerator StartTimeOut()
    {
        while (enabled)
        {
            _newSpawnPosition.y = GetRandomPositionY();
            _newSpawnPosition.x = transform.position.x;

            Pool.TakeObject(_newSpawnPosition, Quaternion.identity);

            yield return Delay;
        }
    }

    private float GetRandomPositionY()
    {
        return Random.Range(_minSpawnValueY, _maxSpawnValueY);
    }
}