using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : PoolItem<T>
{
    [SerializeField] protected Pool<T> Pool;

    [SerializeField] private float _spawnDelay;

    protected Coroutine StartTimeOutWork;
    protected WaitForSeconds Delay;

    protected virtual void Init()
    {
        Delay = new WaitForSeconds(_spawnDelay);
    }

    protected void OffActiveObjects()
    {
        Pool.ReturnAllObjectsInPool();
    }
}