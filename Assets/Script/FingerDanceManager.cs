using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FingerDanceManager : MonoBehaviour
{
    public static FingerDanceManager Instance;

    [Header("UI Elements")]
    public Text scoreText;
    public Text TempoText;
    public GameObject gameOverPanel;

    [Header("Game Settings")]
    public int initialTempo = 3;
    public int initialScore = 0;

    private int score;
    private int tempo;

    public int Tempo
    {
        get { return tempo; }
        set
        {
            
            tempo = Mathf.Clamp(value, 0, 5);
            UpdateUI();
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetGameState();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void AddTempo(int amount)
    {
        Tempo += amount;  
        UpdateUI();
    }

    public void LoseHP(int amount)
    {
        Tempo -= amount;
        UpdateUI();

        if (Tempo <= 0)
        {
            EndGame();
        }
    }

    void UpdateUI()
    {
        scoreText.text = ": " + score;
        TempoText.text = ": " + tempo;
    }

    void EndGame()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;

        
        RandomAudioPlayer randomAudioPlayer = FindObjectOfType<RandomAudioPlayer>();
        if (randomAudioPlayer != null)
        {
            randomAudioPlayer.PlayGameOverSound();
        }
        else
        {
            Debug.LogWarning("RandomAudioPlayer ไม่ถูกพบในซีน!");
        }
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Going to Main Menu");

        ResetGameState();
        gameOverPanel.SetActive(false);
    }

    void ResetGameState()
    {
        score = initialScore;
        Tempo = initialTempo;  
        UpdateUI();
    }
}
