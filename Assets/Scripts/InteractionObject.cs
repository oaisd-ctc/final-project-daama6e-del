/*using UnityEngine.Events;
using UnityEngine;
using System.Collections;


public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "I'm an interactable object";
    [SerializeField] private float delay = 0f;


    public UnityEvent OnInteract = new UnityEvent();


    public string GetInteractionText()
    {
        return interactionText;
    }


    public void Interact()
    {
        StartCoroutine(ExecuteInteraction());
    }

    private IEnumerator ExecuteInteraction()
    {
        yield return new WaitForSeconds(delay);
        OnInteract.Invoke();
        Debug.Log("Object has been iteracted upon.");
    }
}

Above is the retired code for the function, below is more robust. Keeping above code for 'just in case reference'

*/

using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

 //Demands that Unity makes all the below data information into serializeable boxes. And works just fine being right there \/
[System.Serializable] public class InteractionStep //This class is a data cointainer, so its accessable in 
{
    public string stepDescription; // So notes are doable 
    public float delay;            // You know
    public UnityEvent action;      // This is the important drop down list unity provides. All that was done was make this inside another list with the delay needed.
}

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "Interact"; 
    
    [SerializeField] private List<InteractionStep> interactionSequence = new List<InteractionStep>(); //Creates the new list only this script can access and edit in inspector

    public void Interact()
    {
        StartCoroutine(ExecuteSequence());
    }

    private IEnumerator ExecuteSequence()
    {
        foreach (InteractionStep step in interactionSequence) //Follows the list one list container doing the executes one at a time as described in the container class above
        {
            if (step == null) continue; //This fix error of removing list actions.

            yield return new WaitForSeconds(step.delay); //This is the delay

            if (step.action != null)
            {
                step.action.Invoke(); //After delay it will play the list inside the list its in with the delay
            }
        }
    }

    public string GetInteractionText() => interactionText;
} //boy thats a lot of work just to have the first original container nested in another container just to get delay working independantly.