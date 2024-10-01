using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCompoundingManager : MonoBehaviour
{
    public static MainCompoundingManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of \"Main Compounding Manager\" in the current scene");
            Destroy(this);
        } else {
            instance = this;
        }
    }

    [Header("Payer Variables")]
    GameObject playerHeldElement;
    [SerializeField] float playerHeight;
    [SerializeField] Transform playerTransform;

    [Header("Compounding Variables")]
    [SerializeField] GameObject[] slots;
    [SerializeField] String TargetFormula;

    private void OnEnable() {
        GameEventsManager.instance.compoundingEvents.onTestFormula += testFormula;
    }

    private void OnDisable() {
        GameEventsManager.instance.compoundingEvents.onTestFormula -= testFormula;
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.GetComponent<elementBlock>() != null && hit.transform.GetComponent<elementBlock>().interactable) {
                    pickUpBlock(hit.transform);
                    return;
                }

                if (hit.transform.GetComponent<compoundingSlots>() != null && playerHeldElement != null){
                    insertBlockToSlot(hit.transform);
                }
            }
    }

    private void insertBlockToSlot(Transform slot)
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Transform ElementTransform = playerHeldElement.transform;
        ElementTransform.SetParent(slot.transform);
        ElementTransform.localPosition = new Vector3(0, 0.5f, 0);

        playerHeldElement = null;
    }

    public void pickUpBlock(Transform elementBlock){
        if (!Input.GetMouseButtonDown(0)) return;
        elementBlock.SetParent(playerTransform);
        elementBlock.localPosition = new Vector3(0, playerHeight + 0.5f, 0);
        playerHeldElement = elementBlock.gameObject;
    }

    private void testFormula(){
        String compoundElement = "";
        foreach (GameObject slot in slots)
        {
            char slotElementLetter = slot.GetComponent<compoundingSlots>().elementLetter;

            if (slotElementLetter == ' ') return; // TODO: Notify player to fill up all slots

            compoundElement += slotElementLetter;
        }

        if (TargetFormula.ToUpper().Equals(compoundElement.ToUpper())){
            GameEventsManager.instance.compoundingEvents.FormulaCorrect();
        }
    }
}
