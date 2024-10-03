using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelVariablesHandler : MonoBehaviour
{
    [SerializeField] int levelIndex;    // This will indicate what level it is on.
                                        // example: current level is 3. levelIndex should be 2.

    int temporaryStarCount = 3;

    public static levelVariablesHandler instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of \"Level Variable Handler\" in the current scene");
            Destroy(this);
        } else
            instance = this;
    }

    private void OnEnable() {
        GameEventsManager.instance.quizEvents.onQuizIncorrect += reduceLevelStar;
    }
    
    private void OnDisable() {
        GameEventsManager.instance.quizEvents.onQuizIncorrect += reduceLevelStar;
    }

    void reduceLevelStar(){
        temporaryStarCount--;
    }

    public void updateLevelStats(){
        LevelManager.instance.setLevelStars(levelIndex, temporaryStarCount);
    }
}
