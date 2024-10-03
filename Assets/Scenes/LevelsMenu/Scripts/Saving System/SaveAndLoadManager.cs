using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    levelData levelData;
    List<ISaveAndLoad> saveAndLoadObjects;
    public static SaveAndLoadManager instance {get; private set;}

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of " + this.name + " exists in the current scene");
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        this.saveAndLoadObjects = findAllSaveAndLoadObjects();
        loadGame();
    }

    public void newGame(){
        this.levelData = new levelData();
    }

    public void loadGame(){
        if (this.levelData == null){
            Debug.Log("No existing data found. Creating new data");
            newGame();
        }

        foreach (ISaveAndLoad saveAndLoadObject in saveAndLoadObjects)
        {
            saveAndLoadObject.loadData(levelData);
        }
    }

    public void saveGame(){
        foreach (ISaveAndLoad saveAndLoadObject in saveAndLoadObjects)
        {
            saveAndLoadObject.saveData(ref levelData);
        }

        for (int i = 0; i < levelData.levelAvailability.Length; i++)
        {
            PlayerPrefs.SetInt("levelAvailability" + i, levelData.levelAvailability[i] ? 1 : 0);
        }

        for (int i = 0; i < levelData.levelStars.Length; i++)
        {
            PlayerPrefs.SetInt("levelStars" + i, levelData.levelStars[i]);
        }
    }

    private void OnApplicationQuit() {
        saveGame();
    }

    List<ISaveAndLoad> findAllSaveAndLoadObjects(){
        IEnumerable<ISaveAndLoad> saveAndLoadObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveAndLoad>();

        return new List<ISaveAndLoad>(saveAndLoadObjects);
    }
}
