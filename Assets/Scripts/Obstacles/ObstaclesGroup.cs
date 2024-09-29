using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObstaclesGroup : MonoBehaviour
{
    [SerializeField, Min(0.5f)] private float _lifeTime = 0.5f;
    [SerializeField] private MoveableObstacle[] _obstacles;
    [SerializeField] private UnityEvent _obstacleDenied;

    private bool _isActive = false;

    public void SetActive(bool activeStatus)
    {
        _isActive = activeStatus;
        gameObject.SetActive(activeStatus);

        if (activeStatus)
            StartCoroutine(StartLifeCycle());
        else
            _obstacleDenied.Invoke();
    }

    private IEnumerator StartLifeCycle()
    {
        if (_isActive)
            yield return new WaitForSeconds(_lifeTime);

        SetActive(false);
    }
}
