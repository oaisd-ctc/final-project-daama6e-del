using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTab : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private string boolParameterName = "Open";
    [SerializeField] private KeyCode toggleKey = KeyCode.G;

    private bool isOpen = false; //I track som'thin i guess

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isOpen = !isOpen; //THIS IS A TOGGLE! not everything is barebones i guess 
            //See- each time the computer has to do somthing, it will always do the opposite of what is (! opposite operator or NOT)

            if (animator != null)
            {
                animator.SetBool(boolParameterName, isOpen); //Then it sends that result from above after checking if here is an animator in the field so it doesnt crash
                //then sends the result. its the messenger (address, result)
            }
        }

    }
}
