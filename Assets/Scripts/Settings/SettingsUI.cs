using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _sounds;
    [SerializeField] private Button _music;

    [Space(5)]
    [SerializeField] private Settings _settings;

    private void Start()
    {
        ChangeMusicState();
        ChangeSoundsState();
    }

    public void ChangeMusicState()
    {
        float music = 0f;
        music = _settings.GetMusicVolume();
        ChangeButtonState(music, _music);
    }

    public void ChangeSoundsState()
    {
        float sounds = 0f;
        sounds = _settings.GetSoundsVolume();
        ChangeButtonState(sounds, _sounds);
    }

    private void ChangeButtonState(float audio, Button button)
    {
        if (audio == -80f)
            button.image.color = Color.gray;
        else
            button.image.color = Color.white;
    }
}
