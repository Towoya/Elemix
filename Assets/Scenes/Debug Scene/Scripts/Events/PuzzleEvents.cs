using System;

public class PuzzleEvents
{
    public event Action onSolvedFormula;
    public void solvedFomula(){
        if (onSolvedFormula != null){
            onSolvedFormula();
        }
    }
}
