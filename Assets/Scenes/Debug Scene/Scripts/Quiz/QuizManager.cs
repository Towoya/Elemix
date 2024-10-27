using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    static public QuizManager instance { get; private set; }

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
<<<<<<< HEAD
    bool hasAnyOfTheQuizzesFailed = false;
    bool hasCurrentQuizFailed = false;
>>>>>>> main
    
    [Header("PanelVariables")]
=======

    [Header("Panel Variables")]
>>>>>>> main
    public GameObject quizCanvas;
    [SerializeField] Button[] choiceButtons;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Result Panel Variables")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Button closeButton;

<<<<<<< HEAD
        testQuiz();
    }

    void testQuiz(){
=======
    private string[] resultMessages;

    private bool isCorrectAnswer = true;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of \"Quiz Manager\" exists in the current scene");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        quizCanvas.SetActive(false);
        resultPanel.SetActive(false);

        closeButton.onClick.AddListener(() => CloseResultPanel());
    }

    void startQuiz(GameObject container)
    {
        elementContainer = container;
>>>>>>> main
        quizCanvas.SetActive(true);
        initializeQuizValues();
    }

<<<<<<< HEAD
    void initializeQuizValues(){
=======
    public void setQuizValues(string question, string correctAnswer, string[] choices, GameObject container, string[] resultMessages) // Add resultMessages parameter
{
    this.question = question;
    this.correctAnswer = correctAnswer;
    this.choices = choices;

    startQuiz(container);

    // Store result messages for use in choice checks
    this.resultMessages = resultMessages; 
}

    public void initializeQuizValues()
    {
>>>>>>> main
        questionText.text = question;

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI choiceText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choices[i];
        }
    }

<<<<<<< HEAD
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
=======
    public void isChoiceCorrect(int buttonIndex)
{
    string selectedAnswer = choiceButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text;

    if (selectedAnswer.Equals(correctAnswer))
    {
        ShowResult(resultMessages[buttonIndex]); // Use the corresponding result message for correct answer
        if (isCorrectAnswer) GameEventsManager.instance.quizEvents.quizCorrect();
        isCorrectAnswer = true;
    }
    else
    {
        isCorrectAnswer = false;
        ShowResult(resultMessages[buttonIndex]); // Use the corresponding result message for incorrect answer
        GameEventsManager.instance.quizEvents.quizIncorrect();
    }

    // Don't close the quizCanvas yet
    quizCanvas.SetActive(false);
}

// Note: You will also need to declare a field to hold the result messages in QuizManager
// Add this field

        void ShowResult(string message)
    {
        resultText.text = message;  // Update the result text
        resultPanel.SetActive(true); // Show the result panel
        closeButton.gameObject.SetActive(true);  // Ensure the close button is active
        Time.timeScale = 0f;  // Pause the game (optional, depending on your design)
    }

    void CloseResultPanel()
{
    resultPanel.SetActive(false);  // Hide the result panel
    closeButton.gameObject.SetActive(false);  // Ensure the close button is hidden too
    Time.timeScale = 0f;

    if (isCorrectAnswer)
    {
        // Correct answer: Unlock container and allow progress
        GameEventsManager.instance.quizEvents.quizCompleted(elementContainer);
        quizCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    else
    {
        // Incorrect answer: Reopen quiz for another attempt
        quizCanvas.SetActive(true);
    }
}

    void reactivateChoices()
    {
        foreach (Button choice in choiceButtons)
        {
            choice.interactable = true;
        }
    }
>>>>>>> main
}
