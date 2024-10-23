using UnityEngine;

public class levelVariablesHandler : MonoBehaviour
{
    public int levelIndex; // This will indicate what level it is on.

    // example: current level is 3. levelIndex should be 2.

    int temporaryStarCount = 3;
    int temporaryLevelScore = 0;

    bool reducedStarCountOnQuiz = false;

    public static levelVariablesHandler instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(
                "There are more than one instance of \"Level Variable Handler\" in the current scene"
            );
            Destroy(this);
        }
        else
            instance = this;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.quizEvents.onQuizIncorrect += reduceLevelStarOnQuiz;
        GameEventsManager.instance.compoundingEvents.onFormulaIncorrect += reduceLevelStarOnFormula;
        GameEventsManager.instance.quizEvents.onQuizCorrect += incrementLevelScore;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.quizEvents.onQuizIncorrect -= reduceLevelStarOnQuiz;
        GameEventsManager.instance.compoundingEvents.onFormulaIncorrect -= reduceLevelStarOnFormula;
        GameEventsManager.instance.quizEvents.onQuizCorrect -= incrementLevelScore;
    }

    private void Update()
    {
        if (temporaryLevelScore > 10)
        {
            Debug.LogError("Score has exceeded the maximum amount per level");
            temporaryLevelScore = 10;
        }
    }

    void reduceLevelStarOnQuiz()
    {
        if (reducedStarCountOnQuiz) return;
        reducedStarCountOnQuiz = true;
        temporaryStarCount--;
    }

    void reduceLevelStarOnFormula(){
        temporaryStarCount--;
    }

    void incrementLevelScore()
    {
        Debug.Log("Score Incremented");
        temporaryLevelScore++;
    }

    public void updateLevelStats()
    {
        LevelManager.instance.setLevelScore(levelIndex, temporaryLevelScore);
        LevelManager.instance.setLevelStars(levelIndex, temporaryStarCount);
    }
}
