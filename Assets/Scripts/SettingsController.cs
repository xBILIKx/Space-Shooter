using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer Mixer;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void AllAudioVolume(float vol)
    { 
        Mixer.SetFloat("AllMusic", Mathf.Lerp(-80, 0, vol));
    }
    public void AllSoundsVolume(float vol)
    {
        Mixer.SetFloat("Sounds", Mathf.Lerp(-80, 0, vol));
    }
    public void BackgroundMusicVolume(float vol)
    {
        Mixer.SetFloat("BackgroundMusic", Mathf.Lerp(-80, 0, vol));
    }

}
