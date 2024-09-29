using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compoundingManager : MonoBehaviour
{
    public static compoundingManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of " + instance.name + " exists in current scene");
            Destroy(this);
        } else {
            instance = this;
        }
    }

    private void Update() {
        slotClick();
    }

    private void slotClick(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.GetComponent<compoundingSlots>() == null) return;
                if (!Input.GetMouseButtonDown(0)) return;

                hit.transform.GetComponent<compoundingSlots>().insertElement(PlayerManager.instance.playerHeldElement);
                PlayerManager.instance.letGoOfBlock();
            }
    }
    
}
