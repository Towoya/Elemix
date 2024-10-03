using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class levelData
{
    public bool[] levelAvailability;
    public int[] levelStars;

    int numberOfLevels = 10;

    public levelData(){
        this.levelAvailability = new bool[10];
        this.levelStars = new int[10];

        this.levelAvailability[0] = true;
    }
}
