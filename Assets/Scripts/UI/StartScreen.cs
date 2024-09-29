using UnityEngine;
using UnityEngine.Events;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private UnityEvent _gameStart;
    private void Update()
    {
        if  (Input.GetButtonDown(GlobalStringVars.ACTION) ||
            Input.GetButtonDown(GlobalStringVars.HORIZONTAL) ||
            Input.GetButtonDown(GlobalStringVars.VERTICAL))
        {
            _gameStart.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void Reveal()
    {
        gameObject.SetActive(true);
    }
}
