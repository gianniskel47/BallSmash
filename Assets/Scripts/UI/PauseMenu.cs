using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] GameObject gameplayPanel;
    [SerializeField] GameObject pausePanel;

    private void Awake()
    {
        quitButton.onClick.AddListener(Application.Quit);
        mainMenuButton.onClick.AddListener(() => LoadMainMenu());
        resumeButton.onClick.AddListener(() => ResumeGame());
    }

    private void ResumeGame()
    {
        pausePanel.SetActive(false);
        gameplayPanel.SetActive(true);
        GameManager.Instance.ResumeGame();
    }

    private void LoadMainMenu()
    {
        GameManager.Instance.ResumeGame();
        SceneLoader.Instance.LoadSceneByName("StartScene");
    }
}
