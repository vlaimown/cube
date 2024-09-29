using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Score _scoreManager;
    private TMP_Text _score;

    private void Start()
    {
        _score = GetComponent<TMP_Text>();
        _score.text = "Score: 0";
    }

    public void UpdateUI()
    {
        _score.text = $"Score: {_scoreManager.GetScore}";
    }
}
