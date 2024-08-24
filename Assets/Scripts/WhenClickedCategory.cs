using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenClickedCategory : MonoBehaviour
{

    public GameObject Category, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disablecategorybtn()
    {
        GameObject[] categories = { Category, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9 };

        foreach (GameObject category in categories)
        {
            if (category.activeInHierarchy)
            {
                category.SetActive(false);
            }
            else
            {
                category.SetActive(true);
            }
        }
    }
}