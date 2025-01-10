using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : MonoBehaviour where T : PoolItem<T>
{
    [SerializeField] protected PoolItem<T> Prefab;

    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _maxSize;

    protected List<PoolItem<T>> TempStorage;

    private ObjectPool<PoolItem<T>> _pool;

    public event Action Dead;

    private void Awake()
    {
        Init();
    }

    public void TakeObject(Vector2 newPosition, Quaternion rotation)
    {
        PoolItem<T> tempItem;

        tempItem = _pool.Get();
        tempItem.transform.position = newPosition;
        tempItem.transform.rotation = rotation;
    }

    public void ReturnAllObjectsInPool()
    {
        foreach (PoolItem<T> item in TempStorage)
            SetActive(item, false);
    }

    private void ReturnObject(PoolItem<T> item)
    {
        Dead?.Invoke();
        _pool.Release(item);
    }

    private void Init()
    {
        TempStorage = new List<PoolItem<T>>();

        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<PoolItem<T>>(
            createFunc: () => Create(),
            actionOnGet: (item) => OnGet(item, true),
            actionOnRelease: (item) => SetActive(item, false),
            actionOnDestroy: (item) => DestroyItem(item),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _maxSize);
    }

    private void OnGet(PoolItem<T> item, bool isActive)
    {
        SetActive(item, true);
    }

    private void SetActive(PoolItem<T> item, bool isActive)
    {
        item.gameObject.SetActive(isActive);
    }

    private PoolItem<T> Create()
    {
        PoolItem<T> tempItem;

        tempItem = Instantiate(Prefab, transform.position, Quaternion.identity, transform);
        AddListener(tempItem);
        TempStorage.Add(tempItem);

        return tempItem;
    }

    private void DestroyItem(PoolItem<T> item)
    {
        RemoveListener(item);
        Destroy(item);
    }

    private void AddListener(PoolItem<T> item)
    {
        item.Dead += ReturnObject;
    }

    private void RemoveListener(PoolItem<T> item)
    {
        item.Dead -= ReturnObject;
    }
}