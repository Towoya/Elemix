using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageSoreDisplay : MonoBehaviour
{
    [Header("Score Display Variable")]
    [SerializeField]
    int stageIndex;
    TextMeshProUGUI scoreOutput;

    private void Awake()
    {
        scoreOutput = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        int stageScore = LevelManager.instance.GetStageScore(stageIndex);

        scoreOutput.text = "Average Score: " + stageScore + "%";
    }
}
