using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerHeldElement { get; private set; }

    public static PlayerManager instance { get; private set; }

    [Header("Player Variables")]
    [SerializeField] float playerHeight;
    [SerializeField] Transform playerTransform;

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of " + instance.name + " in the current scene");
            Destroy(gameObject);
        } else {
            instance = this;
        }

        // TODO: Get Player Transform
        // TODO: Get Player Height
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.GetComponent<elementBlock>() == null) return;
                if (!Input.GetMouseButtonDown(0)) return;

                pickUpBlock(hit.transform);
            }
    }

    public void pickUpBlock(Transform elementBlock){
        elementBlock.SetParent(playerTransform);
        elementBlock.localPosition = new Vector3(0, playerHeight + 0.5f, 0);
        playerHeldElement = elementBlock.gameObject;
    }
}
