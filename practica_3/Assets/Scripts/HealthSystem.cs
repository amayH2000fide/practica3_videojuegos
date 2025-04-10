using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthBar;     
    public GameObject DeathScreen;
    public Button RetryButton;

    void Start()
    {
        DeathScreen.SetActive(false);
        RetryButton.onClick.AddListener(Retry);
        currentHealth = maxHealth;
        UpdateHealthUI();

        if (DeathScreen != null)
        {
            DeathScreen.SetActive(false); // Asegura que el panel esté oculto al inicio
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta colisión con objetos etiquetados como "Enemigo" o "Obstaculo"
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            TakeDamage(5f); // Puedes ajustar la cantidad de daño
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        DeathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
