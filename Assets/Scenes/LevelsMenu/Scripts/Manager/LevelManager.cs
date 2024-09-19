using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, ISaveAndLoad
{
    bool[] levelAvailability;
    [SerializeField] GameObject[] levelButtons;

    public static LevelManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of " + instance.name + " in the current scene");
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Update() {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Image levelImage = levelButtons[i].GetComponent<Image>();
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelImage.raycastTarget = levelButton.interactable;
        }
    }

    void instantiateLevelButtons(){
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelButton.interactable = levelAvailability[i];
        }
    }

    public void loadData(levelData data)
    {
        this.levelAvailability = data.levelAvailability;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            this.levelAvailability[i] = PlayerPrefs.GetInt("" + i) == 1 ? true : false;
        }

        instantiateLevelButtons();
    }

    public void saveData(ref levelData data)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button levelButton = levelButtons[i].GetComponent<Button>();
            this.levelAvailability[i] = levelButton.interactable;
        }

        data.levelAvailability = this.levelAvailability;
    }
}
