using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int lastScore;
    public int currentScore;

    public AudioSource openningSound;
    public AudioMixerGroup musicAudioMixer;
    public AudioMixerGroup sfxAudioMixer;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            _instance = this;
        }
    }

    private void Start()
    {
        //RESET HIGHSCORE:
        //PlayerPrefs.SetInt("highscore", 0);

        InitializeOptionsPlayerPrefs();
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Vibration.Init();
    }

    public void SaveHighscore(int currentPlayerScore)
    {
        if(!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentPlayerScore);
        }
        else if(PlayerPrefs.GetInt("highscore") < currentPlayerScore)
        {
            PlayerPrefs.SetInt("highscore", currentPlayerScore);
        }
    }

    public int LoadHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }

    public void VibratePhone(long intensity)
    {
        if(PlayerPrefs.GetInt("vibrationOn") == 1)
            Vibration.Vibrate(intensity);
    }

    public void SetAndSaveMusicVolume(float musicVolumeValue)
    {
        musicAudioMixer.audioMixer.SetFloat("musicVolume", musicVolumeValue);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeValue);
    }

    public void SetAndSaveSFXVolume(float sfxVolumeValue)
    {
        sfxAudioMixer.audioMixer.SetFloat("sfxVolume", sfxVolumeValue);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeValue);
    }

    void InitializeOptionsPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
            PlayerPrefs.SetFloat("musicVolume", 0);
        else
            musicAudioMixer.audioMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume"));
        if (!PlayerPrefs.HasKey("sfxVolume"))
            PlayerPrefs.SetFloat("sfxVolume", 0);
        else
            musicAudioMixer.audioMixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("sfxVolume"));

        if (!PlayerPrefs.HasKey("vibrationOn"))
            PlayerPrefs.SetInt("vibrationOn", 1);
        if (!PlayerPrefs.HasKey("screenShakeOn"))
            PlayerPrefs.SetInt("screenShakeOn", 1);
    }
}