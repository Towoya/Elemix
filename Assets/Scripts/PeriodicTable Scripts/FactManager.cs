using System.Collections;
using UnityEngine;
using TMPro; // Include this if you're using TextMeshPro

public class FactManager : MonoBehaviour
{
    public TextMeshProUGUI factText; // Assign this in the Inspector
    private string[] facts;
    private int currentFactIndex = 0;
    private Coroutine factCoroutine;

    void Start()
    {
        // Initialize with default facts for the first element
        facts = new string[]
        {
            "Hydrogen is the most abundant element in the universe.",
            "Helium is the second lightest element.",
            "Lithium is used in rechargeable batteries."
        };

        // Start the coroutine to change facts
        factCoroutine = StartCoroutine(ChangeFact());
    }

    private IEnumerator ChangeFact()
    {
        while (true)
        {
            // Set the current fact
            factText.text = facts[currentFactIndex];

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Update the fact index, looping back to the start if necessary
            currentFactIndex = (currentFactIndex + 1) % facts.Length;
        }
    }

    public void ShowFactsForElement(string element)
    {
        switch (element)
        {
            case "Hydrogen":
                facts = new string[]
                {
                    "Hydrogen is the most abundant element in the universe.",
                    "Hydrogen is the lightest element.",
                    "Hydrogen is the primary fuel for stars."
                };
                break;
            case "Helium":
                facts = new string[]
                {
                    "Helium is the second lightest element.",
                    "Helium is non-flammable.",
                    "Helium is used in balloons and airships."
                };
                break;
            case "Lithium":
                facts = new string[]
                {
                    "Lithium is used in rechargeable batteries.",
                    "Lithium is the lightest metal.",
                    "Lithium is used in mood-stabilizing drugs."
                };
                break;
            case "Carbon":
                facts = new string[]
                {
                    "Carbon is the basis for all known life on Earth.",
                    "Carbon exists in multiple forms like diamond, graphite, and graphene.",
                    "Combines with oxygen to form carbon dioxide (CO₂), which is crucial for photosynthesis and greenhouse effects."
                };
                break;
            default:
                facts = new string[]
                {
                    "Select an element to see facts."
                };
                break;
        }
        currentFactIndex = 0; // Reset fact index for new element

        // Stop the current coroutine and start it again to use the new facts
        if (factCoroutine != null)
        {
            StopCoroutine(factCoroutine);
        }
        factCoroutine = StartCoroutine(ChangeFact());
    }
}
