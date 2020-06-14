using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider allAudioSlider;
    public Slider allSoundsSlider;
    public Slider backgroundMusicSlider;
    float allAudioValue = 1;
    float allSoundsValue = 1;
    float backgroundMusicValue = 1;
    private void Start()
    {
        allAudioSlider.value = allAudioValue;
        allSoundsSlider.value = allSoundsValue;
        backgroundMusicSlider.value = backgroundMusicValue;
    }

    public void AllAudioVolume(float vol)
    { 
        Mixer.SetFloat("AllMusic", Mathf.Lerp(-80, 0, vol));
        allAudioValue = vol;
    }
    public void AllSoundsVolume(float vol)
    {
        Mixer.SetFloat("Sounds", Mathf.Lerp(-80, 0, vol));
        allSoundsValue = vol;
    }
    public void BackgroundMusicVolume(float vol)
    {
        Mixer.SetFloat("BackgroundMusic", Mathf.Lerp(-80, 0, vol));
        backgroundMusicValue = vol;
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("AllAudioVolume"))
        {
            allAudioValue = PlayerPrefs.GetFloat("AllAudioVolume");
            allSoundsValue = PlayerPrefs.GetFloat("AllSoundsVolume");
            backgroundMusicValue = PlayerPrefs.GetFloat("BackgroundMusicVolume");
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("AllAudioVolume", allAudioValue);
        PlayerPrefs.SetFloat("AllSoundsVolume", allSoundsValue);
        PlayerPrefs.SetFloat("BackgroundMusicVolume", backgroundMusicValue);
    }
}
