using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;

    public void Reset()
    {
        _spawner.Reset();
    }

    public void Shoot()
    {
        _spawner.TakeObjectInPool(transform.rotation);
    }
}