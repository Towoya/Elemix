using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, ISaveAndLoad
{
    int numberOfLevels = 50;
    bool[] levelAvailability;
    int[] levelStars;
    int[] levelScore;
    [SerializeField] GameObject[] levelButtons;
    [SerializeField] GameObject[] levelStarContainers;
    [SerializeField] Sprite[] flaskSprites = new Sprite[2]; // 0 - no star
                                                            // 1 - with star

    public static LevelManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of " + instance.name + " in the current scene");
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        levelAvailability = new bool[numberOfLevels];
        levelScore = new int[numberOfLevels];
        levelStars = new int[numberOfLevels];
    }

    private void Update() {
        if (SceneManager.GetActiveScene().buildIndex != 2) return;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Image levelImage = levelButtons[i].GetComponent<Image>();
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelImage.raycastTarget = levelButton.interactable;
        }
    }

    public void setLevelStars(int levelIndex, int numberOfStars){
        if (levelStars[levelIndex] < numberOfStars)
            levelStars[levelIndex] = numberOfStars;

        unlockNextLevel(levelIndex);
    }

    public void setLevelScore(int levelIndex, int score){
        if (levelScore[levelIndex] < score)
            levelScore[levelIndex] = score;
    }

    void unlockNextLevel(int currentLevelIndex){
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex > levelAvailability.Length) {
            Debug.Log("This is the last level of the game");
            return;
        }

        levelAvailability[nextLevelIndex] = true; 
    }

    void instantiateLevelButtons(){
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Button levelButton = levelButtons[i].GetComponent<Button>();
            levelButton.interactable = levelAvailability[i];
        }
    }

    void instantiateLevelStars(){
        for (int i = 0; i < levelStarContainers.Length; i++){
            Image[] starOutputs = levelStarContainers[i].GetComponentsInChildren<Image>();

            int starAmountLeft = levelStars[i];


            foreach (Image starOutput in starOutputs){
                if (starAmountLeft >= 0) {
                    starAmountLeft--;
                    starOutput.sprite = flaskSprites[1];
                } else {
                    starOutput.sprite = flaskSprites[0];
                }
            }
        }
    }

    void instantiateLevelScore(){
        // TODO: Set level score output
    }

    public void loadData(levelData data)
    {
        this.levelAvailability = data.levelAvailability;

        for (int i = 0; i < levelButtons.Length; i++){
            if (!PlayerPrefs.HasKey("levelAvailability" + i)) break;
            this.levelAvailability[i] = PlayerPrefs.GetInt("levelAvailability" + i) == 1 ? true : false;
        }

        this.levelStars = data.levelStars;

        for (int i = 0; i < levelStarContainers.Length; i++){
            if (!PlayerPrefs.HasKey("levelStars" + i)) break;
            this.levelStars[i] = PlayerPrefs.GetInt("levelStars" + i);
        }

        this.levelScore = data.levelScore;

        for (int i = 0; i < levelScore.Length; i++){
            if (!PlayerPrefs.HasKey("levelScore" + i)) break;
            this.levelScore[i] = PlayerPrefs.GetInt("levelScore" + i);
        }

        if (SceneManager.GetActiveScene().buildIndex != 2) return;

        instantiateLevelButtons();
        instantiateLevelStars();
        instantiateLevelScore();
    }

    public void saveData(ref levelData data)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                Button levelButton = levelButtons[i].GetComponent<Button>();
                this.levelAvailability[i] = levelButton.interactable;
            }
        }

        data.levelAvailability = this.levelAvailability;

        data.levelStars = this.levelStars;

        data.levelScore = this.levelScore;
    }
}
