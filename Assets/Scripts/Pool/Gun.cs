using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;

    public void Shoot()
    {
        _spawner.Shoot(transform.rotation);
    }
}