using System;
using UnityEngine;

public class CompoundingEvents
{
    public event Action<GameObject, GameObject, GameObject, string> onTestFormula;

    public void TestedFormula(GameObject door, GameObject button, GameObject compoundingPanel, string targetFormula){
        if (onTestFormula != null)
            onTestFormula(door, button, compoundingPanel, targetFormula);
    }

    public event Action<GameObject> onFormulaCorrect;

    public void FormulaCorrect(GameObject door){
        if (onFormulaCorrect != null)
            onFormulaCorrect(door);
    }

    public event Action onFormulaIncorrect;

    public void formulaIncorrect(){
        if (onFormulaIncorrect != null)
            onFormulaIncorrect();
    }

    public event Action<GameObject> onCloseButton;

    public void buttonClosed(GameObject button){
        if (onCloseButton != null)
            onCloseButton(button);
    }
}
