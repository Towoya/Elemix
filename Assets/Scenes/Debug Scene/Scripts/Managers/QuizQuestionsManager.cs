using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuizQuestionsManager : MonoBehaviour
{
    public QuestionObject[] QuestObj;

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

    public NewSaveData NSD;

    public static QuizQuestionsManager instance
    {
        get; private set;
    }

    public List<int> QuestionList;

    private void Awake()
    {
        /*for (int i = 0; i < questions.Length; i++)
        {
            QuestionObject _qo = new QuestionObject();

            _qo.question = questions[i];
            _qo.answer = answers[i];
            _qo.messageIfCorrect = messageIfCorrect[i];
            _qo.messageIfIncorrect = messageIfIncorrect[i];

            QuestObj[i] = _qo;
        }*/


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

        return QuestObj[NSD.students[NSD.AccountNumber].LevelData.questionList[questionIndex]].question;
    }

    public string[] getChoices(int questionIndex)
    {
        string[] choices = new string[4];

        choices[0] = QuestObj[NSD.students[NSD.AccountNumber].LevelData.questionList[questionIndex]].answer;

        System.Random random = new System.Random();

        for (int i = 1; i < choices.Length; i++)
        {
            string tempString = "";

            while (true)
            {
                tempString = QuestObj[random.Next(0, answers.Length)].answer;

                if (!choices.Contains(tempString))
                    break;
            }

            choices[i] = tempString;
        }

        return KnuthShuffle(choices);
    }

    public string getCorrectAnswer(int questionIndex)
    {
        return QuestObj[NSD.students[NSD.AccountNumber].LevelData.questionList[questionIndex]].answer;
    }

    public string getCorrectMessage(int questionIndex)
    {
        return QuestObj[NSD.students[NSD.AccountNumber].LevelData.questionList[questionIndex]].messageIfCorrect;
    }

    public string getIncorrectMessage(int questionIndex)
    {
        return QuestObj[NSD.students[NSD.AccountNumber].LevelData.questionList[questionIndex]].messageIfIncorrect;
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

[System.Serializable]
public class QuestionObject
{
    public string question;
    public string answer;
    public string messageIfCorrect;
    public string messageIfIncorrect;

}
