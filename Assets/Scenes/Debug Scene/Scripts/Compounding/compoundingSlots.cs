using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    [SerializeField] char elementLetter = ' ';
    [SerializeField] bool interactable;

    private void Update() {
        if (gameObject.transform.childCount == 0) clearElementLetter();
    }

    public void insertElement(GameObject elementBlock){
        if (!interactable) return;
        if (!elementLetter.Equals(' ')) return;
        if (elementBlock == null) return;

        
        char elementBlockLetter = elementBlock.GetComponent<elementBlock>().elementLetter;

        setElementLetter(elementBlockLetter);
        elementBlock.transform.SetParent(this.gameObject.transform);
        elementBlock.transform.localPosition = new Vector3(0, elementBlock.transform.localScale.y/2, 0);
    }

    private void setElementLetter(char letter){
        this.elementLetter = letter;
    }

    private void clearElementLetter(){
        this.elementLetter = ' ';
    }
}
