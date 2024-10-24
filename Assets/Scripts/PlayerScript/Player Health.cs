using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isTouchingBlock;
    public bool stopDealingDamage;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }

        if (isTouchingBlock == true)
        {
            if (stopDealingDamage == false)
            {
                stopDealingDamage = true;
                StartCoroutine(DamageFromBlock());
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hazard Block")
        {
            isTouchingBlock = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Hazard Block")
        {
            isTouchingBlock = false;
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    IEnumerator DamageFromBlock()
    {
        yield return new WaitForFixedUpdate();
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
        stopDealingDamage = false;
    }
}
