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
    string question;
    string[] choices = new string[4];
    string correctAnswer;
    public GameObject elementContainer;

    [Header("Panel Variables")]
    public GameObject quizCanvas;
    [SerializeField] Button[] choiceButtons;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Result Panel Variables")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Button closeButton;

    private string[] resultMessages;

    private bool isCorrectAnswer;

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
        quizCanvas.SetActive(true);
        initializeQuizValues();
    }

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
        questionText.text = question;

        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI choiceText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choices[i];
        }
    }

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
}
