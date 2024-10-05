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

        GameObject closestCompoundingPanel = null;

        foreach (GameObject compoundingPanel in compoundingPanels){
            if (closestCompoundingPanel == null){
                closestCompoundingPanel = compoundingPanel;
                continue;
            }

            if (Vector3.Distance(transform.position, compoundingPanel.transform.position) > Vector3.Distance(transform.position, closestCompoundingPanel.transform.position)) continue;

            closestCompoundingPanel = compoundingPanel;
        }

        this.compoundingPanelTarget = closestCompoundingPanel;
    }

    void setDoorToClosest(){
        if (this.doorTarget != null) return;

        DoorParent[] doors = Object.FindObjectsOfType<DoorParent>();

        GameObject closestDoorObject = null;

        foreach (DoorParent door in doors){
            if (closestDoorObject == null) {
                closestDoorObject = door.gameObject;
                continue;
            }

            if (Vector3.Distance(transform.position, door.transform.position) > Vector3.Distance(transform.position, closestDoorObject.transform.position)) continue;

            closestDoorObject = door.gameObject;
        }

        this.doorTarget = closestDoorObject;
    }
}
