using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class levelData
{
    public bool TutorialCompleted;
    public int questionNumber;
    public int[] questionList;
    public bool[] levelAvailability;
    public bool[] categoryAvailability;
    public int[] levelStars;
    public int[] levelScore;
    public int[] stageScores;

    public int numberOfLevels = 50;
    public int numberOfCategories = 2; // NOTE: Must be changed if there are more than 2 categories

    public levelData()
    {
        this.questionNumber = 0;
        this.TutorialCompleted = false;
        this.questionList = new int[numberOfLevels];
        this.levelAvailability = new bool[numberOfLevels];
        this.categoryAvailability = new bool[numberOfCategories];
        this.levelStars = new int[numberOfLevels];
        this.levelScore = new int[numberOfLevels];
        this.stageScores = new int[numberOfLevels / 5];

        this.levelAvailability[0] = true;
        this.categoryAvailability[0] = true;
    }
}
