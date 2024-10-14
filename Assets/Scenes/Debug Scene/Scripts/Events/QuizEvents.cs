using System;

public class QuizEvents
{
    public event Action onQuizComplete;

    public void quizCompleted(){
        if (onQuizComplete != null)
            onQuizComplete();
    }

    public event Action onQuizIncorrect;

    public void quizIncorrect(){
        if (onQuizIncorrect != null)
            onQuizIncorrect();
    }

    public event Action onQuizCorrect;

    public void quizCorrect(){
        if (onQuizCorrect != null)
            onQuizCorrect();
    }
}
