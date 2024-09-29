using UnityEngine;
using UnityEngine.Events;

public class MoveableObstacle : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _speed = 1.5f;

    [Space(15)]
    [SerializeField] private UnityEvent _obstacleDenied;

    private float _currentSpeed = 0f;

    private int _directionX = 0;
    private int _directionZ = 0;

    private bool _obstacleDelivered = false;

    public void Spawn(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;

        _currentSpeed = _speed;
        SetRotation(spawnPosition);
        SetMoveDirection(spawnPosition);

        _obstacleDelivered = false;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        Move();
    }

    private void SetMoveDirection(Vector3 spawnPosition)
    {
        if (spawnPosition.x == 0)
        {
            if (spawnPosition.z < 0)
                _directionZ = 1;
            else
                _directionZ = -1;

            _directionX = 0;
        }
        else
        {
            if (spawnPosition.x < 0)
                _directionX = 1;
            else
                _directionX = -1;

            _directionZ = 0;
        }
    }

    private void SetRotation(Vector3 spawnPosition)
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

        if (spawnPosition.x != 0)
        {
            transform.Rotate(0f, 90f, 0f, 0f);
        }
    }

    private void Move()
    {
        if (!_obstacleDelivered)
        {
            transform.position += new Vector3(_directionX, 0, _directionZ) * _currentSpeed * Time.deltaTime;
        }
    }

    public void StopMove()
    {
        _currentSpeed = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            _obstacleDenied.Invoke();
            _obstacleDelivered = true;
            gameObject.SetActive(false);
        }
    }
}
