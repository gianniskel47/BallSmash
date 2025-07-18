using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Button startGameButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(() => SceneLoader.Instance.LoadSceneByName("Level 1"));
        quitButton.onClick.AddListener(() => Application.Quit());
        settingsButton.onClick.AddListener(() => SceneLoader.Instance.LoadSceneByName("Settings"));
    }
}
