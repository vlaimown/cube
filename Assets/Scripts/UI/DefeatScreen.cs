using UnityEngine;
using TMPro;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Score _scoreManager;

    public void Reveal()
    {
        _score.text = $"Score: {_scoreManager.GetScore}";
        gameObject.SetActive(true);
    }
}
