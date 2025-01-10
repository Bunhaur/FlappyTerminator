using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    private bool _canShoot;

    private void Awake()
    {
        Init();
    }

    public void Reset()
    {
        OffActiveObjects();
    }

    public void Shoot(Quaternion rotation)
    {
        if (_canShoot == false)
            return;

        _canShoot = false;
        StartTimeOutWork = StartCoroutine(StartTimeOut());

        Pool.TakeObject(transform.position, rotation);
    }

    protected override void Init()
    {
        base.Init();

        _canShoot = true;
    }

    private IEnumerator StartTimeOut()
    {
        yield return Delay;

        _canShoot = true;
    }
}