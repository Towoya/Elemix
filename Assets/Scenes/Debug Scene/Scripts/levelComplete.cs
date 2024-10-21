using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelComplete : MonoBehaviour
{
    [SerializeField]
    bool isLastLevelOfStage;

    [SerializeField]
    bool testSaving;

    private void OnEnable()
    {
        GameEventsManager.instance.levelEvents.onLastLevelOfStage += CalculateStageScore;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.levelEvents.onLastLevelOfStage -= CalculateStageScore;
    }

    private void Update()
    {
        if (!testSaving)
            return;

        testSaving = false;
        levelCompleted();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
            return;

        levelCompleted();
    }

    void CalculateStageScore()
    {
        if (!isLastLevelOfStage) return;

        float result = 0;

        float sumOfPreviousFiveLevels = 0;
        for (int i = 0; i < 5; i++)
        {
            sumOfPreviousFiveLevels += LevelManager.instance.GetLevelScore(
                levelVariablesHandler.instance.levelIndex - i
            );
        }

        result = sumOfPreviousFiveLevels + 50;

        LevelManager.instance.setStageScore(levelVariablesHandler.instance.levelIndex, (int)result);
    }

    void levelCompleted()
    {
        levelVariablesHandler.instance.updateLevelStats();
        CalculateStageScore();
        SaveAndLoadManager.instance.saveGame();
    }
}
