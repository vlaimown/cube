using UnityEngine;
using UnityEngine.Events;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private UnityEvent _gameStart;
    private void Update()
    {
        if  (_inputController.ActionInputDown() || _inputController.HorizontalAxisDown() || _inputController.VerticalAxisDown())
            GameStart();
    }

    public void GameStart()
    {
        _gameStart.Invoke();
        gameObject.SetActive(false);
    }

    public void Reveal()
    {
        gameObject.SetActive(true);
    }
}
