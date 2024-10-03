using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementContainer : MonoBehaviour
{
    [Header("Container Variables")]
    [SerializeField] float containerHeight;
    [SerializeField] float unlockSpeed = 5;
    [SerializeField] bool isContainerOpen;
    private void OnEnable() {
        GameEventsManager.instance.quizEvents.onQuizComplete += unlockContainer;
    }

    private void OnDisable() {
        GameEventsManager.instance.quizEvents.onQuizComplete -= unlockContainer;
    }

    private void Update() {
        if (!isContainerOpen) {
            deactivateElementBlock();
            return;
        }

        activateElementBlock();
        removeChildFromContainer();

        if (transform.position.y < -0.95f)
            Destroy(gameObject);

        transform.position = new Vector3(transform.position.x, transform.position.y - unlockSpeed * Time.deltaTime, transform.position.z);
    }

    void removeChildFromContainer(){
        if (transform.childCount == 0) return;

        Transform elementBlock = transform.GetChild(0);

        elementBlock.SetParent(null);
    }

    void unlockContainer(){
        isContainerOpen = true;
    }

    void activateElementBlock(){
        if (transform.childCount == 0) return;

        transform.GetChild(0).GetComponent<elementBlock>().interactable = true;
    }

    void deactivateElementBlock(){
        if (transform.childCount == 0) return;

        transform.GetChild(0).GetComponent<elementBlock>().interactable = false;
    }
}
