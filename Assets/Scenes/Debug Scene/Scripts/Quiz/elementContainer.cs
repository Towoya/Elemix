using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementContainer : MonoBehaviour
{
    [Header("Container Variables")]
    [SerializeField]
    float containerHeight;

    [SerializeField]
    float unlockSpeed = 5;

    [SerializeField]
    bool isContainerOpen;


    [Header("Quiz Variables")]
    [SerializeField]
    string[] resultMessages = new string[4]; // Add this field for customizable result messages

<<<<<<< HEAD

    private void OnEnable() {
=======
    private void OnEnable()
    {
>>>>>>> main
        GameEventsManager.instance.quizEvents.onQuizComplete += unlockContainer;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.quizEvents.onQuizComplete -= unlockContainer;
    }

<<<<<<< HEAD
    private void Update() {
        if (!isContainerOpen) {
=======
    private void Update()
    {
        startQuiz();

        if (!isContainerOpen)
        {
>>>>>>> main
            deactivateElementBlock();
            return;
        }

        activateElementBlock();
        removeChildFromContainer();

        if (transform.position.y < -0.95f)
            Destroy(gameObject);

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - unlockSpeed * Time.deltaTime,
            transform.position.z
        );
    }

<<<<<<< HEAD

    void startQuiz(){
=======
    void startQuiz()
    {
>>>>>>> main
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject selectedGameObject = hit.transform.gameObject;
            if (selectedGameObject != gameObject)
                return;

            if (!Input.GetMouseButtonDown(0))
                return;

            if (QuizManager.instance.quizCanvas.activeSelf)
                return;

            System.Random random = new System.Random();
            int quizIndex = random.Next(0, 50);

            QuizManager.instance.setQuizValues(
                QuizQuestionsManager.instance.getQuestion(quizIndex),
                QuizQuestionsManager.instance.getCorrectAnswer(quizIndex),
                QuizQuestionsManager.instance.getChoices(quizIndex),
                selectedGameObject,
                QuizQuestionsManager.instance.getCorrectMessage(quizIndex),
                QuizQuestionsManager.instance.getIncorrectMessage(quizIndex),
                quizIndex
            ); // Pass resultMessages

            Time.timeScale = 0f;
        }
    }

<<<<<<< HEAD

    void removeChildFromContainer(){
        if (transform.childCount == 0) return;
=======
    void removeChildFromContainer()
    {
        if (transform.childCount == 0)
            return;
>>>>>>> main

        Transform elementBlock = transform.GetChild(0);

        elementBlock.SetParent(null);
    }

<<<<<<< HEAD
    void unlockContainer(){
=======
    void unlockContainer(GameObject container)
    {
        if (gameObject != container)
            return;
>>>>>>> main
        isContainerOpen = true;
    }

    void activateElementBlock()
    {
        if (transform.childCount == 0)
            return;

        transform.GetChild(0).GetComponent<elementBlock>().interactable = true;
    }

    void deactivateElementBlock()
    {
        if (transform.childCount == 0)
            return;

        transform.GetChild(0).GetComponent<elementBlock>().interactable = false;
    }
}
