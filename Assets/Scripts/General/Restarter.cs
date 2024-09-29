using UnityEngine;

public class Restarter : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private Player _player;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private Score _scoreManager;

    [SerializeField, Space(10)] private Vector3 _respawnPosition = Vector3.zero;

    public void Restart()
    {
        _scoreManager.ClearScore();

        _obstacleSpawner.ClearCurrentObstacle();

        _player.transform.position = _respawnPosition;
        _player.Respawn();
    }
}
