using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button configButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(() => { ResumeGame(); });
        configButton.onClick.AddListener(() => { ConfigMenu(); });
        exitButton.onClick.AddListener(() => { ExitGame(); });
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    void ResumeGame()
    {
        gameObject.SetActive(false);
    }

    void ConfigMenu()
    {
        Debug.Log("Config...");
    }

    void ExitGame()
    {
        Debug.Log("Exit...");
        SceneManager.LoadScene(0);
    }
}
