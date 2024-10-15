using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class levelData
{
    public bool[] levelAvailability;
    public int[] levelStars;
    public int[] levelScore;
    public int[] stageScores;

    int numberOfLevels = 50;

    public levelData()
    {
        this.levelAvailability = new bool[numberOfLevels];
        this.levelStars = new int[numberOfLevels];
        this.levelScore = new int[numberOfLevels];
        this.stageScores = new int[numberOfLevels / 5];

        this.levelAvailability[0] = true;
    }
}
