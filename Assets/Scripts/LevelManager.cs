using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] Player player;
    [SerializeField] Text scoreText;
    [SerializeField] Button pauseButton;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] Canvas pauseMenuCanvas;
    [SerializeField] UsePowerUpButton usePowerUpButton;

    float currentPlayerScore;

    private void Start()
    {
        pauseButton.onClick.AddListener(() => { PauseGame(); });
        usePowerUpButton.GetComponent<Button>().onClick.AddListener(() => 
        {
            if(usePowerUpButton.currentMentosColor == "blue")
                player.Boost(2.5f);
        });
    }

    private void OnEnable()
    {
        cameraFollow.OnPlayerLefScreen += SaveHighscore;
        cameraFollow.OnPlayerLefScreen += ReloadCurrentScene;

        player.OnPlayerPickedMentos += PlayerPickMentos;
    }

    private void OnDisable()
    {
        cameraFollow.OnPlayerLefScreen -= SaveHighscore;
        cameraFollow.OnPlayerLefScreen -= ReloadCurrentScene;

        player.OnPlayerPickedMentos -= PlayerPickMentos;
    }

    void SaveHighscore()
    {
        //Debug.Log("Saving score...");
        GameManager.Instance.SaveHighscore(Mathf.CeilToInt(currentPlayerScore));
    }

    void ReloadCurrentScene()
    {
        //Debug.Log("Reloading current scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if(player.transform.position.y > currentPlayerScore)
        {
            currentPlayerScore = player.transform.position.y;
            currentPlayerScore = Mathf.CeilToInt(currentPlayerScore);
        }
        scoreText.text = "Score: " + currentPlayerScore;
    }

    void PauseGame()
    {
        Debug.Log("Pausing");
        //uiCanvas.gameObject.SetActive(false);
        pauseMenuCanvas.gameObject.SetActive(true);
    }

    void PlayerPickMentos(int quantity, string mentosColor)
    {
        //if (!usePowerUpButton.gameObject.activeSelf)
        //{
            usePowerUpButton.gameObject.SetActive(true);
            usePowerUpButton.gameObject.GetComponent<UsePowerUpButton>().SetMentosProperties(quantity, mentosColor);
        //}
    }


}
