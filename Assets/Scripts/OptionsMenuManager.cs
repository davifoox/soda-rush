using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider sfxVolume;
    [SerializeField] Toggle vibrationToggle;
    [SerializeField] Toggle screenShakeToggle;

    private void Start()
    {
        //sliders:
        musicVolume.onValueChanged.AddListener(delegate { SetMusicVolume(musicVolume.value); });
        sfxVolume.onValueChanged.AddListener(delegate { SetSFXVolume(sfxVolume.value); });

        //toggles:
        vibrationToggle.onValueChanged.AddListener(delegate { SetVibration(vibrationToggle.isOn); });
        screenShakeToggle.onValueChanged.AddListener(delegate { SetScreenShake(screenShakeToggle.isOn); });
    }

    private void OnEnable()
    {
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume");

        vibrationToggle.isOn = IntToBool(PlayerPrefs.GetInt("vibrationOn"));
        screenShakeToggle.isOn = IntToBool(PlayerPrefs.GetInt("screenShakeOn"));
    }

    void SetMusicVolume(float musicVolumeValue)
    {
        GameManager.Instance.SetAndSaveMusicVolume(musicVolumeValue);
    }

    void SetSFXVolume(float sfxVolumeValue)
    {
        GameManager.Instance.SetAndSaveSFXVolume(sfxVolumeValue);
    }

    void SetVibration(bool vibrationToggleValue)
    {
        PlayerPrefs.SetInt("vibrationOn", BoolToInt(vibrationToggleValue));
    }

    void SetScreenShake(bool screenShakeToggleValue)
    {
        PlayerPrefs.SetInt("screenShakeOn", BoolToInt(screenShakeToggleValue));
    }

    bool IntToBool(int number)
    {
        bool boolValue;
        if (number == 0)
            boolValue = false;
        else
            boolValue = true;
        return boolValue;
    }

    int BoolToInt(bool value)
    {
        int number;
        if (value == false)
            number = 0;
        else
            number = 1;
        return number;
    }
}