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
    [SerializeField] Button backFromCreditsButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Canvas initialCanvas;
    [SerializeField] Canvas creditsCanvas;
    [SerializeField] Canvas optionsCanvas;

    private void Start()
    {
        startButton.onClick.AddListener(() => { StartGame(); });
        configButton.onClick.AddListener(() => { ConfigMenu(); });
        storeButton.onClick.AddListener(() => { StoreMenu(); });
        creditsButton.onClick.AddListener(() => { CreditsMenu(); });
        backFromCreditsButton.onClick.AddListener(() => { BackToInitialMenu(); });

        if (PlayerPrefs.HasKey("highscore"))
        {
            highscoreText.text = "Highscore: " + (PlayerPrefs.GetInt("highscore").ToString());
        }
    }

    void StartGame()
    {
        //Debug.Log("Starting Game...");
        GetComponent<AudioSource>().Stop();
        GameManager.Instance.openningSound.Play();
        SceneManager.LoadScene(1);
    }

    void ConfigMenu()
    {
        initialCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }

    void StoreMenu()
    {
        Debug.Log("Store Menu...");
    }

    void CreditsMenu()
    {
        initialCanvas.gameObject.SetActive(false);
        creditsCanvas.gameObject.SetActive(true);
    }

    void BackToInitialMenu() 
    {
        initialCanvas.gameObject.SetActive(true);
        creditsCanvas.gameObject.SetActive(false);
    }
}
