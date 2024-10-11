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
        if (_scoreManager != null)
            _scoreManager.ClearScore();

        if (_obstacleSpawner != null)
            _obstacleSpawner.ClearCurrentObstacle();

        if (_player != null)
        {
            _player.transform.position = _respawnPosition;
            _player.Respawn();
        }
    }
}
