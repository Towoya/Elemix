using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance { get; private set; }

    [Header("Quiz Variables")]
<<<<<<< HEAD
    [SerializeField] private string question;
    [SerializeField] private string[] choices = new string[4];
    [SerializeField] private string correctAnswer;
    private GameObject elementContainer;
=======
    int currentQuizIndex;
    string question;
    string[] choices = new string[4];
    string correctAnswer;
    public GameObject elementContainer;
>>>>>>> main

    [Header("UI Elements")]
    public GameObject quizCanvas;
<<<<<<< HEAD
    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private TextMeshProUGUI questionText;
=======

    [SerializeField]
    Button[] choiceButtons;

    [SerializeField]
    TextMeshProUGUI questionText;
>>>>>>> main

    [Header("Result Panel")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Button closeButton;

<<<<<<< HEAD
=======
    private string correctMessage;
    private string incorrectMessage;

    private bool isCorrectAnswer = true;

>>>>>>> main
    private void Awake()
    {
        if (instance != null)
        {
<<<<<<< HEAD
            Debug.LogError("Multiple instances of QuizManager detected!");
=======
            Debug.LogError(
                "More than one instance of \"Quiz Manager\" exists in the current scene"
            );
>>>>>>> main
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
        closeButton.onClick.AddListener(CloseResultPanel);
    }

    public void SetQuizValues(string question, string correctAnswer, string[] choices, GameObject container)
    {
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.choices = choices;
        this.elementContainer = container;

        StartQuiz();
    }

<<<<<<< HEAD
    private void StartQuiz()
    {
        quizCanvas.SetActive(true);
        InitializeQuizValues();
    }

    private void InitializeQuizValues()
=======
    public void setQuizValues(
        string question,
        string correctAnswer,
        string[] choices,
        GameObject container,
        string correctMessage,
        string incorrectMessage,
        int quizIndex
    ) // Add resultMessages parameter
    {
        this.currentQuizIndex = quizIndex;
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.choices = choices;

        startQuiz(container);

        // Store result messages for use in choice checks
        this.correctMessage = correctMessage;
        this.incorrectMessage = incorrectMessage;
    }

    public void initializeQuizValues()
>>>>>>> main
    {
        questionText.text = question;

        for (int i = 0; i < choices.Length; i++)
        {
            TextMeshProUGUI choiceText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choices[i];
            int index = i; // Capture index for use in the lambda expression
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
        }
    }

<<<<<<< HEAD
    private void OnChoiceSelected(int buttonIndex)
    {
        string selectedAnswer = choiceButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text;

        if (selectedAnswer == correctAnswer)
        {
            ShowResult("Correct!");
            GameEventsManager.instance.quizEvents.quizCorrect();
        }
        else
        {
            ShowResult("Incorrect!");
            GameEventsManager.instance.quizEvents.quizIncorrect();
        }

        quizCanvas.SetActive(false);
    }

    private void ShowResult(string message)
    {
        resultText.text = message;
        resultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseResultPanel()
    {
        resultPanel.SetActive(false);
        Time.timeScale = 1f;
    }
=======
    public void isChoiceCorrect(int buttonIndex)
    {
        string selectedAnswer = choiceButtons[buttonIndex]
            .GetComponentInChildren<TextMeshProUGUI>()
            .text;

        if (selectedAnswer.Equals(correctAnswer))
        {
            reactivateChoices();
            ShowResult(correctMessage); // Use the corresponding result message for correct answer
            if (isCorrectAnswer)
                GameEventsManager.instance.quizEvents.quizCorrect();
            isCorrectAnswer = true;
        }
        else
        {
            choiceButtons[buttonIndex].interactable = false;
            ShowResult(incorrectMessage); // Use the corresponding result message for incorrect answer
            GameEventsManager.instance.quizEvents.quizIncorrect();
            isCorrectAnswer = false;
        }
    }

    // Note: You will also need to declare a field to hold the result messages in QuizManager
    // Add this field

    void ShowResult(string message)
    {
        resultText.text = message; // Update the result text
        resultPanel.SetActive(true); // Show the result panel
        closeButton.gameObject.SetActive(true); // Ensure the close button is active
        Time.timeScale = 0f; // Pause the game (optional, depending on your design)
    }

    void CloseResultPanel()
    {
        resultPanel.SetActive(false); // Hide the result panel
        closeButton.gameObject.SetActive(false); // Ensure the close button is hidden too
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
