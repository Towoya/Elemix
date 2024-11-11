using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour, ISaveAndLoad
{
    bool[] categoryAvailability;
    int numberOfCategories = 1;
    [Header("Category Variables")]
    [SerializeField] GameObject[] categoryButtons;

    [Header("Debugging Variables")]
    [SerializeField] bool testCategoryUnlocking = false;

    public static CategoryManager instance
    {
        get; private set;
    }

    private void Awake()
    {
        /*if (instance != null)
        {
            Debug.LogError("There are more than one instance of Catergory Manager in current scene");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }*/

        categoryButtons = new GameObject[numberOfCategories];
    }

    private void Update()
    {
        if (!testCategoryUnlocking) return;

        testCategoryUnlocking = false;
        UnlockNextCategory(0);
    }

    public void UnlockNextCategory(int currentCategoryIndex)
    {
        int nextCategoryIndex = currentCategoryIndex + 1;

        if (nextCategoryIndex > categoryAvailability.Length)
        {
            Debug.Log("The last category available has already been unlocked");
            return;
        }

        categoryAvailability[nextCategoryIndex] = true;
        SaveAndLoadManager.instance.saveGame();
    }

    void InitiateCategoryButtons()
    {
        if (categoryButtons[0] == null)
            GetCategoryButtons();

        for (int i = 0; i < categoryButtons.Length; i++)
        {
            Button categoryButton = categoryButtons[i].GetComponent<Button>();
            categoryButton.interactable = this.categoryAvailability[i];
        }
    }

    void GetCategoryButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("CategoryButton");

        buttons = buttons.OrderBy(obj => obj.name, new AlphanumComparatorFast()).ToArray();

        Debug.Log(buttons.Length);

        for (int i = 0; i < categoryButtons.Length; i++)
        {
            categoryButtons[i] = buttons[i];
        }
    }

    public void loadData(levelData data)
    {
        this.categoryAvailability = data.categoryAvailability;

        for (int i = 0; i < categoryButtons.Length; i++)
        {
            if (!PlayerPrefs.HasKey("categoryAvailability" + i))
                break;

            this.categoryAvailability[i] = PlayerPrefs.GetInt("categoryAvailability" + i) == 1 ? true : false;
        }

        InitiateCategoryButtons();
    }

    public void saveData(ref levelData data)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < categoryButtons.Length; i++)
            {
                Button categoryButton = categoryButtons[i].GetComponent<Button>();
                this.categoryAvailability[i] = categoryButton.interactable;
            }
        }

        data.categoryAvailability = this.categoryAvailability;
    }
}