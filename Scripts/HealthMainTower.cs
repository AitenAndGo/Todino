using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthMainTower : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            GameOver();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void GameOver()
    {
        // Time.timeScale = 0; // Zatrzymuje czas w grze
        SceneManager.LoadScene(2);
    }
}