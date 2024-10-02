using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "new Element", menuName = "Scriptables/Items/Element")]
public class ElementObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Element;
    }
}
