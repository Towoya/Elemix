using System;

public class LevelEvents
{
    public event Action onLastLevelOfStage;

    public void lastLevelOfStage()
    {
        if (onLastLevelOfStage != null)
            onLastLevelOfStage();
    }
}
