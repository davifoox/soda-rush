using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    [SerializeField] Button startButton;
    [SerializeField] Button configButton;
    [SerializeField] Button storeButton;
    [SerializeField] Button creditsButton;

    private void Start()
    {
        startButton.onClick.AddListener(() => { StartGame(); });
    }

    void StartGame()
    {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene(1);
    }
}
