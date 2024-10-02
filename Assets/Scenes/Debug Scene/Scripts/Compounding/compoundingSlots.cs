using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    public char elementLetter { get; private set; } = ' ';
    [SerializeField] bool interactable;

    private void Update() {
        if (gameObject.transform.childCount < 1) {
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
        this.elementLetter = ' ';
    }
}
