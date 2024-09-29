using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }
}
