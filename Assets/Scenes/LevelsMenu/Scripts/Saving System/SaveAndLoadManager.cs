using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoadManager : MonoBehaviour
{
    /*List<ISaveAndLoad> saveAndLoadObjects;*/

    public static SaveAndLoadManager instance
    {
        get; private set;
    }

    public NewSaveData NSD;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(
                "More than one instance of " + this.name + " exists in the current scene"
            );
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 2 && scene.buildIndex != 5 && scene.buildIndex != 1)
            return;

        //SetSaveAndLoadObjects();
        loadGame();
    }

    /*public void SetSaveAndLoadObjects()
    {
        this.saveAndLoadObjects = findAllSaveAndLoadObjects();
    }*/

    public void newGame()
    {
        //this.levelData = new levelData();
    }

    public void loadGame()
    {
        /*if (this.levelData == null)
        {
            Debug.Log("No existing data found. Creating new data");
            newGame();
        }*/

        /*foreach (ISaveAndLoad saveAndLoadObject in saveAndLoadObjects)
        {
            saveAndLoadObject.loadData(levelData);
        }*/

        if (LevelManager.instance != null)
            LevelManager.instance.loadData();
    }

    public void saveGame()
    {
        /*foreach (ISaveAndLoad saveAndLoadObject in saveAndLoadObjects)
            saveAndLoadObject.saveData(ref levelData);*/

        if (LevelManager.instance != null)
            LevelManager.instance.saveData();
        /*
                for (int i = 0; i < levelData.levelAvailability.Length; i++)
                    PlayerPrefs.SetInt("levelAvailability" + i, levelData.levelAvailability[i] ? 1 : 0);

                for (int i = 0; i < levelData.categoryAvailability.Length; i++)
                    PlayerPrefs.SetInt("categoryAvailability" + i, levelData.categoryAvailability[i] ? 1 : 0);

                for (int i = 0; i < levelData.levelStars.Length; i++)
                    PlayerPrefs.SetInt("levelStars" + i, levelData.levelStars[i]);

                for (int i = 0; i < levelData.levelScore.Length; i++)
                    PlayerPrefs.SetInt("levelScore" + i, levelData.levelScore[i]);

                for (int i = 0; i < levelData.stageScores.Length; i++)
                    PlayerPrefs.SetInt("stageScore" + i, levelData.stageScores[i]);

                for (int i = 0; i < levelData.questionList.Length; i++)
                    PlayerPrefs.SetInt("questionList" + i, levelData.questionList[i]);

                SaveStudentData();*/


    }

    /*public void SaveStudentData()
    {
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
        {
            NSD.students[NSD.AccountNumber].LevelData.TutorialCompleted = true;
        }
        else
        {
            NSD.students[NSD.AccountNumber].LevelData.TutorialCompleted = false;
        }


        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelAvailability.Length; i++)
        {
            if (PlayerPrefs.GetInt("levelAvailability" + i, 0) == 1)
            {
                NSD.students[NSD.AccountNumber].LevelData.levelAvailability[i] = true;
            }
            else
            {
                NSD.students[NSD.AccountNumber].LevelData.levelAvailability[i] = false;
            }
        }

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.categoryAvailability.Length; i++)
        {
            if (PlayerPrefs.GetInt("categoryAvailability" + i, 0) == 1)
            {
                NSD.students[NSD.AccountNumber].LevelData.categoryAvailability[i] = true;
            }
            else
            {
                NSD.students[NSD.AccountNumber].LevelData.categoryAvailability[i] = false;
            }
        }

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelStars.Length; i++)
        {
            NSD.students[NSD.AccountNumber].LevelData.levelStars[i] = PlayerPrefs.GetInt("levelStars" + i, 0);
        }

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelScore.Length; i++)
        {
            NSD.students[NSD.AccountNumber].LevelData.levelScore[i] = PlayerPrefs.GetInt("levelScore" + i, 0);
        }

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.stageScores.Length; i++)
        {
            NSD.students[NSD.AccountNumber].LevelData.stageScores[i] = PlayerPrefs.GetInt("stageScore" + i, 0);
        }
    }*/

    /*public void LoadStudentData()
    {
        if (NSD.students[NSD.AccountNumber].LevelData.TutorialCompleted)
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TutorialCompleted", 0);
        }

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.questionList.Length; i++)
            PlayerPrefs.SetInt("questionList" + i, NSD.students[NSD.AccountNumber].LevelData.questionList[i]);

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelAvailability.Length; i++)
            PlayerPrefs.SetInt("levelAvailability" + i, NSD.students[NSD.AccountNumber].LevelData.levelAvailability[i] ? 1 : 0);

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.categoryAvailability.Length; i++)
            PlayerPrefs.SetInt("categoryAvailability" + i, NSD.students[NSD.AccountNumber].LevelData.categoryAvailability[i] ? 1 : 0);

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelStars.Length; i++)
            PlayerPrefs.SetInt("levelStars" + i, NSD.students[NSD.AccountNumber].LevelData.levelStars[i]);

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelScore.Length; i++)
            PlayerPrefs.SetInt("levelScore" + i, NSD.students[NSD.AccountNumber].LevelData.levelScore[i]);

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.stageScores.Length; i++)
            PlayerPrefs.SetInt("stageScore" + i, NSD.students[NSD.AccountNumber].LevelData.stageScores[i]);
    }*/
    private void OnApplicationQuit()
    {
        //saveGame();
    }

    /*List<ISaveAndLoad> findAllSaveAndLoadObjects()
    {
        IEnumerable<ISaveAndLoad> saveAndLoadObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<ISaveAndLoad>();

        return new List<ISaveAndLoad>(saveAndLoadObjects);
    }*/
}
