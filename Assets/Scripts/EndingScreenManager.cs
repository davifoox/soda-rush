using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreenManager : MonoBehaviour
{
    [SerializeField] AudioSource goodSound;
    [SerializeField] AudioSource badSound;
    [SerializeField] Button backToInitialMenuButton;
    [SerializeField] Button restartButton;
    [SerializeField] Text endingText;

    private void Start()
    {
        string message;
        if(GameManager.Instance.lastScore < GameManager.Instance.currentScore)
        {
            goodSound.Play();
            message = "NEW RECORD: \n";
        }
        else
        {
            badSound.Play();
            message = "Your score: \n";
        }
        endingText.text = message + GameManager.Instance.currentScore;

        backToInitialMenuButton.onClick.AddListener(() => { BackToInitialMenu(); });
        restartButton.onClick.AddListener(() => { RestartGame(); });
    }

    void BackToInitialMenu()
    {
        SceneManager.LoadScene(0);
    }
    void RestartGame()
    {
        GameManager.Instance.openningSound.Play();
        SceneManager.LoadScene(1);
    }
}
