using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct Stage
{
    [SerializeField, Range(0.3f, 1f)] private float _spawnTimeObstacle;
    [SerializeField, Range(1f, 3f)] private float _minToNextStage;

    public float SpawnTimeObstacle => _spawnTimeObstacle;
    public float MinToNextStage => _minToNextStage * 60;
}

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Stage[] _stages;

    [Space(10)]
    [SerializeField] private MoveableObstacle[] _obstacles;
    [Space(10)]
    [SerializeField] private Transform[] _spawnPoints;

    private MoveableObstacle _currentObstacle;
    private Transform _currentSpawnPoint;

    private int _currentStage = 0;

    private void Start()
    {
        _currentStage = 0;
    }

    public void StartSpawn()
    {
        StartCoroutine(TimeToNextStage());
        CountDownSpawnNext();
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    public void RestartSpawn()
    {
        StopSpawn();
        StartSpawn();
    }

    public void CountDownSpawnNext()
    {
        StartCoroutine(TimeToSpawn());
    }

    private void SpawnObstacle()
    {
        int random = UnityEngine.Random.Range(0, _obstacles.Length);
        _currentObstacle = _obstacles[random];

        random = UnityEngine.Random.Range(0, _spawnPoints.Length);
        _currentSpawnPoint = _spawnPoints[random];

        _currentObstacle.Spawn(_currentSpawnPoint.position);
    }

    public void StopCurrentObstacle()
    {
        _currentObstacle.StopMove();
    }

    public void ClearCurrentObstacle()
    {
        _currentObstacle.gameObject.SetActive(false);
    }

    private IEnumerator TimeToSpawn()
    {
        yield return new WaitForSeconds(_stages[_currentStage].SpawnTimeObstacle);
        SpawnObstacle();
    }

    private IEnumerator TimeToNextStage()
    {
        yield return new WaitForSeconds(_stages[_currentStage].MinToNextStage);

        print("Speed up!");

        if (_currentStage + 1 < _stages.Length)
        {
            _currentStage += 1;
            StartCoroutine(TimeToNextStage());
        }
    }
}
