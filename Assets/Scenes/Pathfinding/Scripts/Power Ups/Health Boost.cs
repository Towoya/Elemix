using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthBar healthBar;
    public int addHealth = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
            healthBar.SetHealth(playerHealth.currentHealth);
        }
    }
    void PickUp()
    {
        playerHealth.currentHealth += addHealth;
        Destroy(gameObject);
        if (playerHealth.currentHealth > 100)
        {
            playerHealth.currentHealth = 100;
        }
    }
}
