using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] PlayerBehaviour player;
    [SerializeField] Text scoreText;
    [SerializeField] Button pauseButton;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] Canvas pauseMenuCanvas;

    float currentPlayerScore;

    private void Start()
    {
        pauseButton.onClick.AddListener(() => { PauseGame(); });
    }

    private void OnEnable()
    {
        cameraFollow.OnPlayerLefScreen += SaveHighscore;
        cameraFollow.OnPlayerLefScreen += ReloadCurrentScene;
    }

    private void OnDisable()
    {
        cameraFollow.OnPlayerLefScreen -= SaveHighscore;
        cameraFollow.OnPlayerLefScreen -= ReloadCurrentScene;
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
}
