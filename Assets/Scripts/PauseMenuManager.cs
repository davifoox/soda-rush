using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] Button resumeButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(() => { ResumeGame(); });
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
}
