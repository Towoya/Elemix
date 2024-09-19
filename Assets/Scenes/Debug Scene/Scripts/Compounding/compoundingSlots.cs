using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    public char? molecularLetter { get; private set; }
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Clicked");
            // Test
            placeIntoSlot('a');
            char? playerElement = PlayerManager.instance.playerHeldElement;
            if (playerElement != null){
                setMolecularLetter(playerElement);
                // TODO: fill placeIntoSlot function which places the cube model of the player held element into the slot
            }
        }
    }

    private void setMolecularLetter(char? molecularLetter) {
        this.molecularLetter = molecularLetter;
    }

    // Test Variables
    [SerializeField] GameObject testObject;

    private void placeIntoSlot(char? molecularLetter) {
        testObject.transform.SetParent(gameObject.transform);
        testObject.transform.localPosition = Vector3.zero;
    }
}
