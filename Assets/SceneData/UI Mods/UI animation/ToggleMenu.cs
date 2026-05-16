using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private string boolParameterName = "Open";
    [SerializeField] private KeyCode toggleKey = KeyCode.M;

    private bool isOpen = false; //I track som'thin i guess
    private bool coursor = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isOpen = !isOpen; //THIS IS A TOGGLE! not everything is barebones i guess 
            coursor = !coursor;
            //See- each time the computer has to do somthing, it will always do the opposite of what is (! opposite operator or NOT)

            if (animator != null)
            {
                animator.SetBool(boolParameterName, isOpen); //Then it sends that result from above after checking if here is an animator in the field so it doesnt crash
                //then sends the result. its the messenger (address, result)
            }

            if (coursor == true)
            {
                Cursor.lockState = CursorLockMode.None; //Shows coursor
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; //Hides coursor
            }
        }
    }
}
