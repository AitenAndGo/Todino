using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class B : MonoBehaviour
{
    public float bulletLifetime = 2.0f; // Czas �ycia naboju w sekundach

    public float bulletDamage = 10f;

    private void Start()
    {
        // life time of bullet
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Sprawdzamy, czy trafiono w obiekt z komponentem zdrowia
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Wywo�ujemy funkcj� TakeDamage, aby odj�� zdrowie
            health.TakeDamage(bulletDamage);
        }

        // destroying bullet after hit in any object
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy trafiono w obiekt z komponentem zdrowia
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            // Wywo�ujemy funkcj� TakeDamage, aby odj�� zdrowie
            health.TakeDamage(bulletDamage);
        }

        // destroying bullet after hit in any object
        Destroy(gameObject);
    }
}

