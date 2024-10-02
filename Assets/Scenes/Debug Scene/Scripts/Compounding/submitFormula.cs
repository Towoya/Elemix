using UnityEngine;

public class submitFormula : MonoBehaviour
{
    private void OnMouseDown() {
        Debug.Log("Submit Button Activated");
        GameEventsManager.instance.compoundingEvents.TestedFormula();
    }
}
