using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Text interactableName;
//InteractionObject

    private InteractionObject targetInteraction;


    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        string interactionText = "";
        targetInteraction = null;


        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
            //print("It interacted"); //Debugger
        }


        if (targetInteraction && targetInteraction.enabled) //If it is vaild and if interaction script is enabled
        {
            interactionText = targetInteraction.GetInteractionText();
        }


        SetInteractableNameText(interactionText);
    }


    private void SetInteractableNameText(string newText)
    {
        if (interactableName)
        {
            interactableName.text = newText;
        }
    }


    public void tryInteract()
    {
        if (targetInteraction)
        {
            targetInteraction.Interact();
        }
    }
}