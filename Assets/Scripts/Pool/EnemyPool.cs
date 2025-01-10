public class EnemyPool : Pool<Enemy>
{
    public void Reset()
    {
        foreach (Enemy enemy in TempStorage)
            enemy.Reset();
    }
}