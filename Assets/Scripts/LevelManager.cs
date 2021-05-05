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

    float currentPlayerScore;

    private void Start()
    {
        pauseButton.onClick.AddListener(() => { PauseGame(); });

    }

    private void OnEnable()
    {
        cameraFollow.OnPlayerLefScreen += ReloadCurrentScene;
    }

    private void OnDisable()
    {
        cameraFollow.OnPlayerLefScreen -= ReloadCurrentScene;
    }

    void ReloadCurrentScene()
    {
        Debug.Log("Reloading current scene");
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
        Debug.Log("PAUSE");
    }
}
