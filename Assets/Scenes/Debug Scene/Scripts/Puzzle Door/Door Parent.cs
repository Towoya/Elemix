using UnityEngine;

public class DoorParent : MonoBehaviour
{
    [SerializeField] float doorOpeningSpeed = 5;
    [SerializeField] bool doorOpened = false;

    private void OnEnable() {
        GameEventsManager.instance.puzzleEvents.onSolvedFormula += openDoor;
    }

    private void OnDisable() {
        GameEventsManager.instance.puzzleEvents.onSolvedFormula -= openDoor;
    }

    private void Update() {
        if (doorOpened){
            float newYScale = transform.localScale.y - doorOpeningSpeed * Time.deltaTime;
            openingAnimation(newYScale);
        }

        if (transform.localScale.y <= 0.05f)
            Destroy(gameObject);
    }

    // Door Opening
    public void openDoor(){
        doorOpened = true;
    }

    void openingAnimation(float newYScale){
        transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);
    }
}
