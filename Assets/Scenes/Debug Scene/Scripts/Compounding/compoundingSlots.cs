using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    [SerializeField] char? elementLetter = null;
    [SerializeField] bool interactable;

    public void insertElement(GameObject elementBlock){
        if (!interactable) return;
        if (elementLetter != null) return;
        
        char elementBlockLetter = elementBlock.GetComponent<elementBlock>().elementLetter;

        setElementLetter(elementBlockLetter);
        elementBlock.transform.SetParent(this.gameObject.transform);
        elementBlock.transform.localPosition = Vector3.zero;
    }

    private void setElementLetter(char letter){
        this.elementLetter = letter;
    }

    private void clearElementLetter(){
        this.elementLetter = null;
    }
}
