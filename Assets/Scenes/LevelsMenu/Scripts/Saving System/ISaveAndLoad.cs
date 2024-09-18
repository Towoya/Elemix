using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveAndLoad
{
    void loadData(levelData data);

    void saveData(ref levelData data);
}
