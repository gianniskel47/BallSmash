using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour
{
    private const string HIGHSCORE = "Highscore";

    [Header("References")]
    [SerializeField] Button playAgainButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Awake()
    {
        playAgainButton.onClick.AddListener(() => SceneLoader.Instance.LoadSceneByName("Level 1"));
        mainMenuButton.onClick.AddListener(() => SceneLoader.Instance.LoadSceneByName("StartScene"));
    }

    private void Start()
    {
        int currentScore = GameManager.Instance.FinalScore;

        if (PlayerPrefs.HasKey(HIGHSCORE) && PlayerPrefs.GetInt(HIGHSCORE) > currentScore )
        {
            highScoreText.text = $"HIGHSCORE: {PlayerPrefs.GetInt(HIGHSCORE).ToString()}";
        }
        else
        {
            highScoreText.text = $"HIGHSCORE: {currentScore.ToString()}";
            PlayerPrefs.SetInt(HIGHSCORE, currentScore);
        }
    }
}
