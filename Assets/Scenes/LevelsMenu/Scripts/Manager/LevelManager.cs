using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public NewSaveData NSD;

    int numberOfLevels = 50;
    [SerializeField]
    bool[] levelAvailability;
    [SerializeField]
    int[] levelStars;
    [SerializeField]
    int[] levelScore;
    [SerializeField]
    int[] stageScore;

    [SerializeField]
    GameObject[] levelButtons;

    GameObject[] levelStarContainers;

    [SerializeField]
    Sprite[] flaskSprites = new Sprite[2]; // 0 - no star

    // 1 - with star

    public static LevelManager instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(
                "There are more than one instance of " + instance.name + " in the current scene"
            );
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        levelAvailability = new bool[numberOfLevels];
        levelScore = new int[numberOfLevels];
        levelStars = new int[numberOfLevels];
        levelButtons = new GameObject[5];
        stageScore = new int[numberOfLevels / 5];
        levelStarContainers = new GameObject[5];
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
            return;

        if (levelButtons[0] == null)
            GetButtons();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            Image levelImage = levelButtons[i].GetComponent<Image>();
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelImage.raycastTarget = levelButton.interactable;
        }
    }

    void GetButtons()
    {
        Button[] buttons = new Button[5];

        Button[] tempArray = FindObjectsOfType<Button>();
        int count = 0;
        foreach (Button tempButton in tempArray)
        {
            if (tempButton.name == "Back")
                continue;

            buttons[count] = tempButton;
            count++;
        }

        buttons = buttons.OrderBy(obj => obj.name, new AlphanumComparatorFast()).ToArray();

        for (int i = 0; i < 5; i++)
        {
            levelButtons[i] = buttons[i].gameObject;
        }
    }

    void GetLevelStarContainers()
    {
        RectTransform[] objects = Resources.FindObjectsOfTypeAll<RectTransform>();

        GameObject[] levelStats = new GameObject[5];

        int levelStatsIndex = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            if (!objects[i].tag.Equals("perLevelStats"))
                continue;
            levelStats[levelStatsIndex] = objects[i].gameObject;
            levelStatsIndex++;
        }

        levelStats = levelStats.OrderBy(obj => obj.name, new AlphanumComparatorFast()).ToArray();

        foreach (GameObject test in levelStats)
        {
            Debug.Log(test.name);
        }

        GameObject[] tempLevelStarContainer = new GameObject[5];
        for (int i = 0; i < tempLevelStarContainer.Length; i++)
        {
            for (int j = 0; j < levelStats[i].transform.childCount; j++)
            {
                HorizontalLayoutGroup container = levelStats[i]
                    .transform.GetChild(j)
                    .GetComponent<HorizontalLayoutGroup>();

                if (container == null)
                    continue;

                tempLevelStarContainer[i] = container.gameObject;
                break;
            }
        }

        levelStarContainers = tempLevelStarContainer;
    }

    public void setStageScore(int levelIndex, int stageScore)
    {
        if (this.stageScore[levelIndex - 4] < stageScore)
            this.stageScore[levelIndex - 4] = stageScore;
    }

    public void setLevelStars(int levelIndex, int numberOfStars)
    {
        if (levelStars[levelIndex] < numberOfStars)
            levelStars[levelIndex] = numberOfStars;

        unlockNextLevel(levelIndex);
    }

    public void setLevelScore(int levelIndex, int score)
    {
        if (levelScore[levelIndex] < score)
            levelScore[levelIndex] = score;
    }

    public int GetLevelScore(int index)
    {
        return levelScore[index];
    }

    void unlockNextLevel(int currentLevelIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
            return;

        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex > levelAvailability.Length)
        {
            Debug.Log("This is the last level of the game");
            return;
        }

        levelAvailability[nextLevelIndex] = true;
    }

    void instantiateLevelButtons()
    {
        if (levelButtons[0] == null)
            GetButtons();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelButton.interactable = levelAvailability[i];
        }
    }

    void instantiateLevelStars()
    {
        if (levelStarContainers[0] == null)
            GetLevelStarContainers();

        for (int i = 0; i < levelStarContainers.Length; i++)
        {
            Image[] starOutputs = levelStarContainers[i].GetComponentsInChildren<Image>();

            int starAmountLeft = levelStars[i];

            foreach (Image starOutput in starOutputs)
            {
                if (starAmountLeft >= 0)
                {
                    starAmountLeft--;
                    starOutput.sprite = flaskSprites[1];
                }
                else
                {
                    starOutput.sprite = flaskSprites[0];
                }
            }
        }
    }

    public int GetStageScore(int StageIndex)
    {
        return stageScore[StageIndex];
    }

    public void loadData()
    {
        //this.levelAvailability = NSD.students[NSD.AccountNumber].LevelData.levelAvailability;

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelAvailability.Length; i++)
        {
            this.levelAvailability[i] = NSD.students[NSD.AccountNumber].LevelData.levelAvailability[i];
        }

        /*for (int i = 1; i < levelButtons.Length; i++)
        {
            if (!PlayerPrefs.HasKey("levelAvailability" + i))
                break;
            this.levelAvailability[i] =
                PlayerPrefs.GetInt("levelAvailability" + i) == 1 ? true : false;
        }*/

        //this.levelStars = NSD.students[NSD.AccountNumber].LevelData.levelStars;

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelStars.Length; i++)
        {
            this.levelStars[i] = NSD.students[NSD.AccountNumber].LevelData.levelStars[i];
        }

        /*for (int i = 0; i < levelStarContainers.Length; i++)
        {
            if (!PlayerPrefs.HasKey("levelStars" + i))
                break;
            this.levelStars[i] = PlayerPrefs.GetInt("levelStars" + i);
        }*/

        //this.levelScore = NSD.students[NSD.AccountNumber].LevelData.levelScore;

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.levelScore.Length; i++)
        {
            this.levelScore[i] = NSD.students[NSD.AccountNumber].LevelData.levelScore[i];
        }

        /*for (int i = 0; i < levelScore.Length; i++)
        {
            if (!PlayerPrefs.HasKey("levelScore" + i))
                break;
            this.levelScore[i] = PlayerPrefs.GetInt("levelScore" + i);
        }*/

        //this.stageScore = NSD.students[NSD.AccountNumber].LevelData.stageScores;

        for (int i = 0; i < NSD.students[NSD.AccountNumber].LevelData.stageScores.Length; i++)
        {
            this.stageScore[i] = NSD.students[NSD.AccountNumber].LevelData.stageScores[i];
        }

        /*for (int i = 0; i < stageScore.Length; i++)
        {
            if (!PlayerPrefs.HasKey("stageScore" + i))
                break;
            this.stageScore[i] = PlayerPrefs.GetInt("stageScore" + i);
        }*/

        if (SceneManager.GetActiveScene().buildIndex != 2)
            return;

        instantiateLevelButtons();
        instantiateLevelStars();
        //NOTE: No Implementation of stage score display
    }

    public void saveData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Button levelButton = levelButtons[i].GetComponent<Button>();
                this.levelAvailability[i] = levelButton.interactable;
            }
        }

        NSD.students[NSD.AccountNumber].LevelData.levelAvailability = this.levelAvailability;

        NSD.students[NSD.AccountNumber].LevelData.levelStars = this.levelStars;

        NSD.students[NSD.AccountNumber].LevelData.levelScore = this.levelScore;

        NSD.students[NSD.AccountNumber].LevelData.stageScores = this.stageScore;

        SaveToJson();
    }

    public void SaveToJson()
    {
        string saveData = JsonUtility.ToJson(NSD);
        Debug.Log(saveData);
        string _filePath = Application.persistentDataPath + "/Elemix.json";
        System.IO.File.WriteAllText(_filePath, saveData);
    }
}
