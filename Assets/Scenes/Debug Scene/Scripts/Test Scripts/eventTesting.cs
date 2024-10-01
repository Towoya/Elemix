using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTesting : MonoBehaviour
{
    [SerializeField] bool activateTest = false;

    private void Update() {
        if (activateTest) {
            activateTest = false;
            GameEventsManager.instance.compoundingEvents.TestedFormula();
        }
    }
}
