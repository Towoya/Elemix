using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance { get; private set; }

    [Header("Quiz Variables")]
    [SerializeField] private string question;
    [SerializeField] private string[] choices = new string[4];
    [SerializeField] private string correctAnswer;
    private GameObject elementContainer;

    [Header("UI Elements")]
    public GameObject quizCanvas;
    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private TextMeshProUGUI questionText;

    [Header("Result Panel")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Button closeButton;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple instances of QuizManager detected!");
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

    private void StartQuiz()
    {
        quizCanvas.SetActive(true);
        InitializeQuizValues();
    }

    private void InitializeQuizValues()
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
}
