using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get { return "Hydrogen"; }
    }
    public Sprite _Image = null;
    public Sprite Image
    {
        get { return _Image; }
    }
    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
