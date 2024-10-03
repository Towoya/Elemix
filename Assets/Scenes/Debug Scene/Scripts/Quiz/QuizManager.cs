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
    [SerializeField] string question;
    [SerializeField] string[] choices = new string[4];
    [SerializeField] string correctAnswer;
    bool incorrectAnswerChosen = false;
    
    [Header("PanelVariables")]
    public GameObject quizCanvas;
    [SerializeField] Button[] choiceButtons;
    [SerializeField] TextMeshProUGUI questionText;

    private void Start() {
        if (choices.Length != 4) {
            Debug.LogError("The number of choices are not equal to 4");
            choices = new string[4];
        }

        quizCanvas.SetActive(false);
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)){
                if (hit.transform.gameObject != GameObject.Find("Element Container")) return;

                if (!Input.GetMouseButtonDown(0)) return;

                startQuiz();
            }
    }

    public void startQuiz(){
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

    public void isChoiceCorrect(int buttonIndex){
        if (!choiceButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text.Equals(correctAnswer)){
            if (!incorrectAnswerChosen){
                incorrectAnswerChosen = true;
                GameEventsManager.instance.quizEvents.quizIncorrect();
            }
            choiceButtons[buttonIndex].interactable = false;
            return;
        }

        quizCanvas.SetActive(false);
        GameEventsManager.instance.quizEvents.quizCompleted();
    }
}
