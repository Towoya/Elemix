using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelComplete : MonoBehaviour
{
    [SerializeField] bool testSaving;
    private void Update() {
        if (!testSaving) return;

        testSaving = false;
        levelCompleted();
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        levelCompleted();
    }

    void levelCompleted(){
        levelVariablesHandler.instance.updateLevelStats();
        SaveAndLoadManager.instance.saveGame();
    }
}
