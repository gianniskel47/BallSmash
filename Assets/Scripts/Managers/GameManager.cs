using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [Header("Config")]
    [SerializeField] int pointsPerBlock = 2;
    [Range(0.1f , 5f)] [SerializeField] float levelSpeed = 1f;
    [SerializeField] bool isAutoPlaying;

    public int FinalScore { get; private set; }
    public bool IsPaused { get; set; }

    private int currentScore = 0;

    private void Awake()
    {
       if(GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

       Instance = this;
       DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Time.timeScale = levelSpeed;     
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
    }

    public void GameOver()
    {
        FinalScore = currentScore;
        SceneLoader.Instance.LoadSceneByName("EndScene");
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
        AudioManager.Instance.StopMusic();
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = levelSpeed;
        AudioManager.Instance.ResumeMusic();
    }

    // this is for testing. when enabled, the paddle follows
    // the ball so you cannot lose
    public bool AutoPlayEnabled()
    {
        return isAutoPlaying;
    } 
}
