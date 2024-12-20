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
    public GameManagerScript gameManager;
    private bool isDead;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        if (isTouchingBlock == true)
        {
            if (stopDealingDamage == false)
            {
                stopDealingDamage = true;
                StartCoroutine(DamageFromBlock());
            }
        }

        //healthBar.SetHealth(currentHealth);

        if (currentHealth == 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hazard Block" || collider.tag == "Door")
        {
            isTouchingBlock = true;
        }

        if (collider.tag == "Door")
        {
            isTouchingBlock = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Hazard Block" || collider.tag == "Door")
        {
            isTouchingBlock = false;
        }

        if (collider.tag == "Door")
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
