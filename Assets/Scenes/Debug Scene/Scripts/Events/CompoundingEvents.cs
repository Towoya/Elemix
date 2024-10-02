using System;

public class CompoundingEvents
{
    public event Action onTestFormula;

    public void TestedFormula(){
        if (onTestFormula != null)
            onTestFormula();
    }

    public event Action onFormulaCorrect;

    public void FormulaCorrect(){
        if (onFormulaCorrect != null)
            onFormulaCorrect();
    }
}
