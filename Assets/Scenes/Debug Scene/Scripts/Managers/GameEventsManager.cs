using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {get; private set;}

    public PuzzleEvents puzzleEvents;

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of " + this.name + " exists in the current scene");
            Destroy(this);
        }
        instance = this;

        puzzleEvents = new PuzzleEvents();
    }
}
