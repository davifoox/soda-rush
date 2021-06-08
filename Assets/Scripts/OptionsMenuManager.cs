using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider sfxVolume;
    [SerializeField] Toggle vibrationToggle;
    [SerializeField] Toggle screenShakeToggle;

    private void Start()
    {
        //pauseButton.onClick.AddListener(() => { PauseGame(); });
        musicVolume.onValueChanged.AddListener(delegate { SetMusicVolume(musicVolume.value); });
        sfxVolume.onValueChanged.AddListener(delegate { SetSFXVolume(sfxVolume.value); });

        vibrationToggle.onValueChanged.AddListener(delegate { SetVibration(vibrationToggle.isOn); });
        screenShakeToggle.onValueChanged.AddListener(delegate { SetScreenShake(screenShakeToggle.isOn); });
    }

    void SetMusicVolume(float musicVolumeValue)
    {
        Debug.Log(musicVolumeValue);
    }

    void SetSFXVolume(float sfxVolumeValue)
    {
        Debug.Log(sfxVolumeValue);
    }

    void SetVibration(bool vibrationToggleValue)
    {
        Debug.Log("vibration: " + vibrationToggleValue);
    }

    void SetScreenShake(bool screenShakeToggleValue)
    {
        Debug.Log("screen shake: " + screenShakeToggleValue);
    }
}