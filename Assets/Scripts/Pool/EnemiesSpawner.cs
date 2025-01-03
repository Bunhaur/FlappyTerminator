using System.Collections;
using UnityEngine;

public class EnemiesSpawner : Spawner<Enemy>
{
    [SerializeField] private float _maxSpawnValueY;
    [SerializeField] private float _minSpawnValueY;

    private Vector3 _newSpawnPosition;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartTimeOutWork = StartCoroutine(StartTimeOut());
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