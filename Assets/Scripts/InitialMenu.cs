using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialMenuManager : MonoBehaviour
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
        Debug.Log("START");
    }
}
