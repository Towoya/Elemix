using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingArrow : MonoBehaviour
{
    public Transform target; // The object the arrow should point to
    public float rotateSpeed = 5f; // Speed of rotation

    void Update()
    {
        if (target != null)
        {
            // Get the direction from the player's position to the target's position
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the angle in 2D space (Z-axis rotation only)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation to the arrow, preserving X and Y axis, but rotating around Z
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90, 0, angle), Time.deltaTime * rotateSpeed);
        }
    }
}

