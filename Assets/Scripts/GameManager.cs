using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Vibration.Vibrate(intensity);
    }
}