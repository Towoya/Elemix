using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour
{
    [Header("Materials")]
    public Material highlightMaterial;  // Assign the highlight material in the Inspector
    public Material selectionMaterial;  // Assign the selection material in the Inspector

    private Material originalMaterial;  // To store the original material of the object
    private MeshRenderer meshRenderer;  // Cache the MeshRenderer component
    private bool isSelected = false;    // Flag to track if the object is selected

    void Start()
    {
        // Cache the MeshRenderer and store the original material
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    void OnMouseEnter()
    {
        if (!isSelected)
        {
            // Change the material to the highlight material when mouse hovers over
            meshRenderer.material = highlightMaterial;
        }
    }

    void OnMouseExit()
    {
        if (!isSelected)
        {
            // Revert back to the original material when the mouse leaves
            meshRenderer.material = originalMaterial;
        }
    }

    void OnMouseDown()
    {
        // When the object is clicked, set the selection material
        if (!isSelected)
        {
            meshRenderer.material = selectionMaterial;
            isSelected = true;
        }
        else
        {
            // If already selected, revert to original material and deselect
            meshRenderer.material = originalMaterial;
            isSelected = false;
        }
    }
}

