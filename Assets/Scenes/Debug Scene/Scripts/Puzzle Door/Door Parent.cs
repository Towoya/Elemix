using UnityEngine;

public class DoorParent : MonoBehaviour
{
    [SerializeField] float doorOpeningSpeed = 5;
    [SerializeField] bool doorOpened = false;

    private void OnEnable() {
        GameEventsManager.instance.puzzleEvents.onSolvedFormula += formulaSolved;
    }

    private void OnDisable() {
        GameEventsManager.instance.puzzleEvents.onSolvedFormula -= formulaSolved;
    }

    private void Update() {
        if (doorOpened){
            float newYPosition = transform.position.y - doorOpeningSpeed * Time.deltaTime;
            openingAnimation(newYPosition);
        }

        if (transform.position.y <= -0.995f)
            Destroy(gameObject);
    }

    // Door Opening
    void formulaSolved(){
        doorOpened = true;
    }

    void openingAnimation(float newYPosition){
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}