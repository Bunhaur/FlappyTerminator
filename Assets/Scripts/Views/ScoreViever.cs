using TMPro;
using UnityEngine;

public class ScoreViever : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private TextMeshProUGUI _text;

    private int _count = 0;

    private void OnEnable()
    {
        _pool.Dead += AddCount;
    }

    private void OnDisable()
    {
        _pool.Dead -= AddCount;
    }

    public void Reset()
    {
        _count = 0;

        Show();
    }

    private void AddCount()
    {
        _count++;

        Show();
    }

    private void Show()
    {
        _text.text = $"{_count}";
    }
}