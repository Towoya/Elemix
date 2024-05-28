using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectAnimation : MonoBehaviour
{
    public Vector3 rotation;

    void Update()
    {
        transform.Rotate(rotation * 1 * Time.deltaTime);
    }
}
