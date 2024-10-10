using Unity.VisualScripting;
using UnityEngine;

public class submitFormula : MonoBehaviour
{
    [SerializeField] GameObject doorTarget;
    [SerializeField] GameObject compoundingPanelTarget;

    bool interactable = true;

    private void OnEnable() {
        GameEventsManager.instance.compoundingEvents.onCloseButton += closeButton;
    }

    private void OnDisable() {
        GameEventsManager.instance.compoundingEvents.onCloseButton -= closeButton;
    }

    private void OnMouseDown() {
        if (!interactable) return;
        setDoorToClosest();
        setCompoundingPanelToClosest();
        GameEventsManager.instance.compoundingEvents.TestedFormula(doorTarget, gameObject, compoundingPanelTarget);
    }

    void closeButton(GameObject button){
        if (gameObject != button) return;
        interactable = false;
    }

    void setCompoundingPanelToClosest(){
        if (this.compoundingPanelTarget != null) return;

        GameObject[] compoundingPanels = GameObject.FindGameObjectsWithTag("CompoundingPanel");

        this.compoundingPanelTarget = findClosestToButton(compoundingPanels);
    }

    void setDoorToClosest(){
        if (this.doorTarget != null) return;

        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");

        this.doorTarget = findClosestToButton(doors);
    }

    GameObject findClosestToButton(GameObject[] objectsToPickFrom){
        GameObject result = null;
        
        foreach (GameObject item in objectsToPickFrom){
            if (result == null) {
                result = item;
                continue;
            }

            Transform objectTransform = item.transform;
            float distanceBetweenButtonAndObject =  Vector3.Distance(transform.position, objectTransform.position); 
            float distanceBetweenButtonAndCurrentClosestObject = Vector3.Distance(transform.position, result.transform.position);

            if (distanceBetweenButtonAndObject > distanceBetweenButtonAndCurrentClosestObject) continue;

            result = item;
        }

        return result;
    }
}
