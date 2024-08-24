using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private float multiplier = 1.5f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }
    void PickUp()
    {
        Debug.Log("Picked Up");
        Destroy(gameObject);
        PlayerMovement.speed *= multiplier;
    }
}