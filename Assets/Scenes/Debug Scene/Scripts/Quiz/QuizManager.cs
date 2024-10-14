using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    static public QuizManager instance { get; private set; }

    private void Awake() {
        if (instance != null) {
            Debug.LogError("More than one instance of \"Quiz Manager\" exists in the current scene");
            Destroy(this);
        } else {
            instance = this;
        }
    }

    [Header("Quiz Variables")]
<<<<<<< HEAD
    [SerializeField] string question;
    [SerializeField] string[] choices = new string[4];
    [SerializeField] string correctAnswer;
    bool incorrectAnswerChosen = false;
=======
    string question;
    string[] choices = new string[4];
    string correctAnswer;
    public GameObject elementContainer;
    bool hasAnyOfTheQuizzesFailed = false;
    bool hasCurrentQuizFailed = false;
>>>>>>> main
    
    [Header("PanelVariables")]
    public GameObject quizCanvas;
    [SerializeField] Button[] choiceButtons;
    [SerializeField] TextMeshProUGUI questionText;

    private void Start() {
        if (choices.Length != 4) {
            Debug.LogError("The number of choices are not equal to 4");
            choices = new string[4];
        }

        testQuiz();
    }

    void testQuiz(){
        quizCanvas.SetActive(true);
        initializeQuizValues();
    }

    void initializeQuizValues(){
        questionText.text = question;

        for (int i = 0; i < 4; i++){
            TextMeshProUGUI choiceText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choices[i];
        }
    }

<<<<<<< HEAD
=======
    void reactivateChoices(){
        hasCurrentQuizFailed = false;
        foreach (Button choice in choiceButtons){
            choice.interactable = true;
        }
    }

>>>>>>> main
    public void isChoiceCorrect(int buttonIndex){
        if (!choiceButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text.Equals(correctAnswer)){
            if (!hasAnyOfTheQuizzesFailed){
                hasAnyOfTheQuizzesFailed = true;
                hasCurrentQuizFailed = true;
                GameEventsManager.instance.quizEvents.quizIncorrect();
            }
            choiceButtons[buttonIndex].interactable = false;
            return;
        }
        
        Time.timeScale = 1f;

        if (!hasCurrentQuizFailed) GameEventsManager.instance.quizEvents.quizCorrect();

        quizCanvas.SetActive(false);
        GameEventsManager.instance.quizEvents.quizCompleted();
    }
}
