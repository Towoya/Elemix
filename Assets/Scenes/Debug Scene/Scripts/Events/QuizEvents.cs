using System;
using UnityEngine;

public class QuizEvents
{
    public event Action<GameObject> onQuizComplete;

    public void quizCompleted(GameObject container){
        if (onQuizComplete != null)
            onQuizComplete(container);
    }

    public event Action onQuizIncorrect;

    public void quizIncorrect(){
        if (onQuizIncorrect != null)
            onQuizIncorrect();
    }
}
