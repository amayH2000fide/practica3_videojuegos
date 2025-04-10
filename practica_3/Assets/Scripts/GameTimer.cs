using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // Tiempo inicial en segundos
    public TextMeshProUGUI timerText; // Campo de UI con TMP
    public GameObject gameOverPanel;  // Panel que se muestra cuando se acaba el tiempo

    private bool timerIsRunning = true;

    void Start()
    {
        UpdateTimerUI();
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Oculta el panel de derrota al inicio
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        Debug.Log("¡Tiempo agotado! Has perdido.");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
