using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementContainer : MonoBehaviour
{
    [Header("Container Variables")]
    [SerializeField] float containerHeight;
    [SerializeField] float unlockSpeed = 5;
    [SerializeField] bool isContainerOpen;

    [Header("Quiz Variables")]
    [SerializeField] string question;
    [SerializeField] string[] choices = new string[4];
    [SerializeField] string correctAnswer;
    [SerializeField] string[] resultMessages = new string[4]; // Add this field for customizable result messages

    private void OnEnable() {
        GameEventsManager.instance.quizEvents.onQuizComplete += unlockContainer;
    }

    private void OnDisable() {
        GameEventsManager.instance.quizEvents.onQuizComplete -= unlockContainer;
    }

    private void Update() {
        startQuiz();

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

    void startQuiz(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)){
                GameObject selectedGameObject = hit.transform.gameObject;
                if (selectedGameObject != gameObject) return;

                if (!Input.GetMouseButtonDown(0)) return;

                if (QuizManager.instance.quizCanvas.activeSelf) return;

                QuizManager.instance.setQuizValues(question, correctAnswer, choices, selectedGameObject, resultMessages); // Pass resultMessages

                Time.timeScale = 0f;
            }
    }

    void removeChildFromContainer(){
        if (transform.childCount == 0) return;

        Transform elementBlock = transform.GetChild(0);

        elementBlock.SetParent(null);
    }

    void unlockContainer(GameObject container){
        if (gameObject != container) return;
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
