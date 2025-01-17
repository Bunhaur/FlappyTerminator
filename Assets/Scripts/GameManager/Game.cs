using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private ScoreViever _score;
    [SerializeField] private Player _player;

    private float _openAlphaValue = 1;
    private float _closeAlphaValue = 0;

    private void Awake()
    {
        Init();

        _endScreen.Closed(_closeAlphaValue, false);
        _startScreen.Open(_openAlphaValue, true);
    }

    private void OnEnable()
    {
        _startScreen.Clicked += StartGame;
        _endScreen.Clicked += RestartGame;
        _player.Dead += OpenRestartScreen;
    }

    private void OnDisable()
    {
        _startScreen.Clicked += StartGame;
        _endScreen.Clicked -= RestartGame;
        _player.Dead -= OpenRestartScreen;
    }

    private void OpenRestartScreen()
    {
        _endScreen.Open(_openAlphaValue, true);
    }

    private void RestartGame()
    {
        _enemiesSpawner.Reset();
        _endScreen.Closed(_closeAlphaValue, false);
        _player.Reset();
        _score.Reset();
    }

    private void Init()
    {
        _enemiesSpawner.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);
        _score.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        _enemiesSpawner.gameObject.SetActive(true);
        _player.gameObject.SetActive(true);
        _score.gameObject.SetActive(true);

        _startScreen.gameObject.SetActive(false);

        RestartGame();
    }
}