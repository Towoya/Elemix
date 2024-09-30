using UnityEngine;

public class compoundingSlots : MonoBehaviour
{
    [SerializeField] char elementLetter = ' ';
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
