using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public int money = 150;

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
            FindObjectOfType<Money>().addMoney(money);
            FindObjectOfType<GameManager>().enemydead += 1;
        }
    }

    private void Die()
    {
        // Tutaj mo�esz umie�ci� kod, kt�ry wykona si� po �mierci obiektu, np. dezaktywowa� go, wywo�a� efekt itp.
        Destroy(gameObject);
    }
}
