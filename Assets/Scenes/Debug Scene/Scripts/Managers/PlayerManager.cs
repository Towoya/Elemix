using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Nullable<char> playerHeldElement { get; private set; }

    public static PlayerManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of " + instance.name + " in the current scene");
            Destroy(gameObject);
        } else {
            instance = this;
        }

        playerHeldElement = null;
    }
}
