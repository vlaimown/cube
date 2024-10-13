using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    [SerializeField] private UnityEvent _musicMuted;
    [SerializeField] private UnityEvent _soundsMuted;

    public void MuteMusic()
    {
        if (GetMusicVolume() == 0f)
            _mixer.SetFloat("Music", -80f);
        else
            _mixer.SetFloat("Music", 0f);

        _musicMuted.Invoke();
    }

    public void MuteSounds()
    {
        if (GetSoundsVolume() == 0f)
            _mixer.SetFloat("Sounds", -80f);
        else
            _mixer.SetFloat("Sounds", 0f);

        _soundsMuted.Invoke();
    }

    public float GetMusicVolume()
    {
        float music = 0f;
        _mixer.GetFloat("Music", out music);

        return music;
    }

    public float GetSoundsVolume()
    {
        float sounds = 0f;
        _mixer.GetFloat("Sounds", out sounds);

        return sounds;
    }
}
