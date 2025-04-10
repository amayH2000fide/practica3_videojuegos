using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 20f; // Cantidad de daño que este enemigo inflige
    public bool useTrigger = false;  // Cambiar a true si se quiere usar OnTriggerEnter en lugar de OnCollisionEnter

    private void OnCollisionEnter(Collision collision)
    {
        if (!useTrigger && collision.gameObject.CompareTag("Player"))
        {
            ApplyDamage(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (useTrigger && other.CompareTag("Player"))
        {
            ApplyDamage(other.gameObject);
        }
    }

    void ApplyDamage(GameObject player)
    {
        HealthSystem health = player.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}