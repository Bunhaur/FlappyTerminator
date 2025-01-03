using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : MonoBehaviour where T : PoolItem<T>
{
    [SerializeField] protected PoolItem<T> Prefab;

    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _maxSize;

    private PoolItem<T> _tempItem;
    private ObjectPool<PoolItem<T>> _pool;

    private void Awake()
    {
        Init();
    }

    public void TakeObject(Vector2 newPosition, Quaternion rotation)
    {
        _tempItem = _pool.Get();
        _tempItem.transform.position = newPosition;
        _tempItem.transform.rotation = rotation;
    }

    public void ReturnObject(PoolItem<T> item)
    {
        _pool.Release(item);
    }

    private void Init()
    {
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
        _tempItem = Instantiate(Prefab, transform.position, Quaternion.identity, transform);

        AddListener(_tempItem);

        return _tempItem;
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