using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDamage : MonoBehaviour
{
    public bool isTouchingBlock;
    public bool stopDealingDamage;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hazard Block")
        {
            isTouchingBlock = true;
        }

        if (collider.CompareTag("Player"))
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

        if (collider.CompareTag("Player"))
        {
            isTouchingBlock = false;
        }
    }
    IEnumerator DamageFromBlock()
    {
        yield return new WaitForSeconds(1);
        playerHealth.maxHealth -= 5;
        stopDealingDamage = false;
    }
}
