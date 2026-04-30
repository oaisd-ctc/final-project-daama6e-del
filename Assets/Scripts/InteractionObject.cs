using UnityEngine.Events;
using UnityEngine;
using System;


public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "I'm an interactable object";


    public UnityEvent OnInteract = new UnityEvent();


    public string GetInteractionText()
    {
        return interactionText;
    }


    public void Interact()
    {
        OnInteract.Invoke();
        Debug.Log("Is it working?");
    }
}
