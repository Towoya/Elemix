using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public Transform target; // Target for the pathfinding
    public GridLayout grid; // Reference to the GridLayout script
    private List<Node> path; // The path returned from the pathfinding
    public float moveSpeed = 5f; // Speed of the player

    void Update() {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                // Find the target node based on the mouse click
                Node targetNode = grid.NodeFromWorldPoint(hit.point);
                Node startNode = grid.NodeFromWorldPoint(transform.position);

                // Use the Pathfinding script to get the path
                Pathfinding pathfinding = GetComponent<Pathfinding>();
                pathfinding.FindPath(startNode.worldPosition, targetNode.worldPosition);
                path = grid.path; // Access the path directly from the grid
            }
        }

        MoveAlongPath();
    }

    void MoveAlongPath() {
        if (path != null && path.Count > 0) {
            Vector3 targetPosition = path[0].worldPosition;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the player has reached the target position
            if (transform.position == targetPosition) {
                path.RemoveAt(0); // Move to the next node in the path
            }
        }
    }
}
