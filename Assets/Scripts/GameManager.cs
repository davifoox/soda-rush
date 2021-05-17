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
            _instance = this;
        }
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
}