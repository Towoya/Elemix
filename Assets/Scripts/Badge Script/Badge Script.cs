using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BadgeScript : MonoBehaviour
{
    int stageIndex;
    public GameObject badgePanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        badgePanel.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Start()
    {
        DisplayBadgePanel();
    }

    void DisplayBadgePanel()
    {
        int passingScore = 75;
        int stageScore = LevelManager.instance.GetStageScore(stageIndex);

        if (stageScore >= passingScore)
        {
            badgePanel.SetActive(true);
        }
    }
}
