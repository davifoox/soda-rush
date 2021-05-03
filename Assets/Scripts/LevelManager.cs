using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] CameraFollow cameraFollow;

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
}
