using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] GameObject gameplayPanel;

    private void Start()
    {
        levelText.text = $"Level: {SceneLoader.Instance.GetCurrentSceneIndex().ToString()}";
        pauseButton.onClick.AddListener(() => PauseButtonClick());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        gameplayPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        GameManager.Instance.ResumeGame();
    }

    public void PauseButtonClick()
    {
        if (GameManager.Instance.IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
