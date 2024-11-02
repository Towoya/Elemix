using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizQuestionsManager : MonoBehaviour
{
    [Header("Question Variables")]
    [SerializeField]
    string[] questions = new string[50];

    [SerializeField]
    string[] answers = new string[50];

    [Header("FeedBack Variables")]
    [SerializeField]
    string[] messageIfCorrect = new string[50];

    [SerializeField]
    string[] messageIfIncorrect = new string[50];

    public static QuizQuestionsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(
                "There are more than one instance of Quiz Question Manager in current scene"
            );
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public string getQuestion(int questionIndex)
    {
        return questions[questionIndex];
    }

    public string[] getChoices(int questionIndex)
    {
        string[] choices = new string[4];

        choices[0] = answers[questionIndex];

        System.Random random = new System.Random();

        for (int i = 1; i < choices.Length; i++)
        {
            string tempString = "";

            while (true)
            {
                tempString = answers[random.Next(0, answers.Length)];

                if (!choices.Contains(tempString))
                    break;
            }

            choices[i] = tempString;
        }

        return KnuthShuffle(choices);
    }

    public string getCorrectAnswer(int questionIndex)
    {
        return answers[questionIndex];
    }

    public string getCorrectMessage(int questionIndex)
    {
        return messageIfCorrect[questionIndex];
    }

    public string getIncorrectMessage(int questionIndex)
    {
        return messageIfIncorrect[questionIndex];
    }

    T[] KnuthShuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < array.Length; i++)
        {
            int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        return array;
    }
}
