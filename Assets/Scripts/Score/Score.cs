using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private UnityEvent _updateScore;
    private int _score = 0;

    public void IncreaseScore(int value = 1)
    {
        _score += value;
        _updateScore.Invoke();
    }

    public void ClearScore()
    {
        _score = 0;
        _updateScore.Invoke();
    }

    public int GetScore => _score;
}
