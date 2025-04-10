using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollector : MonoBehaviour
{
    
    public int collectibleCount = 0;
    public TextMeshProUGUI collectibleText;
    public GameObject winScreen;
    public Button RetryButton;

    private void Start()
    {
        winScreen.SetActive(false);
        UpdateUI();
    }

    public void AddCollectible()
    {
        collectibleCount++;
        Debug.Log("Coleccionables: " + collectibleCount);
        UpdateUI();
    }

    public void winCondition()
    {
        if (collectibleCount == 20)
        {
            GameWon();
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameWon()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void UpdateUI()
    {
        if (collectibleText != null)
        {
            collectibleText.text = "Coleccionables: " + collectibleCount;
        }
        else
        {
            Debug.LogError("¡collectibleText no está asignado en el Inspector!");
        }

    }
}
