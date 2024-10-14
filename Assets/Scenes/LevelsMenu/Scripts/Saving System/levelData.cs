using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class levelData
{
    public bool[] levelAvailability;
    public int[] levelStars;
    public int[] levelScore;

    int numberOfLevels = 50;

    public levelData(){
        this.levelAvailability = new bool[numberOfLevels];
        this.levelStars = new int[numberOfLevels];
        this.levelScore = new int[numberOfLevels];

        this.levelAvailability[0] = true;
    }
}
