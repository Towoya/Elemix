using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    public string elementLetter { get; private set; } = " ";
    [SerializeField] bool interactable;

    private void Update() {
        bool thisSlotHasChild = gameObject.transform.childCount < 1;

        if (thisSlotHasChild) {
            clearElementLetter();
            return;
        }

        GameObject elementBlock = gameObject.transform.GetChild(0).gameObject;

        setElementLetter(elementBlock);
    }

    public void setElementLetter(GameObject elementBlock){
        elementLetter = elementBlock.GetComponent<elementBlock>().elementLetter;
    }

    private void clearElementLetter(){
        this.elementLetter = " ";
    }
}
