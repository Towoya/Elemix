using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
    public Unit unit; // Reference to the Unit script

    void Update() {
        if (Input.GetMouseButtonDown(1)) { // Check if the left mouse button is clicked
            SetTargetPosition();
        }
    }

    void SetTargetPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            Vector3 targetPosition = hit.point; // Get the point where the ray hits
            unit.target.position = targetPosition; // Set the target position in the Unit script
            PathRequestManager.RequestPath(unit.transform.position, targetPosition, unit.OnPathFound);
        }
    }
}
