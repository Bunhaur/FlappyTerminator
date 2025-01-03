using System;
using UnityEngine;

public abstract class PoolItem<T> : MonoBehaviour where T : PoolItem<T>
{
    public event Action<PoolItem<T>> Dead;

    protected void DeadAction()
    {
        Dead?.Invoke(this);
    }
}