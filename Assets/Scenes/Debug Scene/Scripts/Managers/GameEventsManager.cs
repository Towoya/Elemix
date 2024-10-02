using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {get; private set;}

    public CompoundingEvents compoundingEvents;

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of " + this.name + " exists in the current scene");
            Destroy(gameObject);
        }
        instance = this;

        compoundingEvents = new CompoundingEvents();
    }
}
