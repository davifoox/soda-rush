using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreenManager : MonoBehaviour
{
    [SerializeField] Button backToInitialMenuButton;
    [SerializeField] Button restartButton;
    [SerializeField] Text endingText;

    private void Start()
    {
        string message;
        if(GameManager.Instance.lastScore < GameManager.Instance.currentScore)
            message = "NEW RECORD: \n";
        else
            message = "Your score: \n";
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
        SceneManager.LoadScene(1);
    }
}
