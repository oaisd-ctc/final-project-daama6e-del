
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class InputHandler : MonoBehaviour
{


    FirstPersonCamera firstPersonCamera;
    CharacterMovement characterMovement;
    PlayerInteraction playerInteraction;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera = GetComponent<FirstPersonCamera>(); //Interesting they are all the same legnth
        characterMovement = GetComponent<CharacterMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();


    }


    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
        HandleMovementInput();
        HandleInteractionInput();
    }


    void HandleCameraInput()
    {
        firstPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        firstPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }


    void HandleMovementInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");


        characterMovement.AddMoveInput(forwardInput, rightInput);
    }


    void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E)) //If pressed E on interactable, try to interact from PlayerInteraction script /\
        {
            playerInteraction.tryInteract();
        }
    }
}