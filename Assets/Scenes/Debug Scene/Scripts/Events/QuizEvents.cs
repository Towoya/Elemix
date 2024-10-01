using System;

public class QuizEvents
{
    public event Action onQuizComplete;

    public void quizCompleted(){
        if (onQuizComplete != null)
            onQuizComplete();
    }
}
