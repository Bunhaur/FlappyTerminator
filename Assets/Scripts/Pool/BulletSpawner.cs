using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    private bool _canSpawn;

    private void Awake()
    {
        Init();
    }

    public void Reset()
    {
        OffActiveObjects();
    }

    public void TakeObjectInPool(Quaternion rotation)
    {
        if (_canSpawn == false)
            return;

        _canSpawn = false;
        StartTimeOutWork = StartCoroutine(StartTimeOut());

        Pool.TakeObject(transform.position, rotation);
    }

    protected override void Init()
    {
        base.Init();

        _canSpawn = true;
    }

    private IEnumerator StartTimeOut()
    {
        yield return Delay;

        _canSpawn = true;
    }
}