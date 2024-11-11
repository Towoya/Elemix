using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public levelVariablesHandler lVH;

    public static GameEventsManager instance
    {
        get; private set;
    }

    public CompoundingEvents compoundingEvents;
    public QuizEvents quizEvents;
    public LevelEvents levelEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(
                "More than one instance of " + this.name + " exists in the current scene"
            );
            Destroy(gameObject);
        }

        instance = this;
        Debug.Log(
                 "New instance of " + this.name + " created"
             );

        compoundingEvents = new CompoundingEvents();
        quizEvents = new QuizEvents();
        levelEvents = new LevelEvents();

        lVH.enabled = true;
    }
}
