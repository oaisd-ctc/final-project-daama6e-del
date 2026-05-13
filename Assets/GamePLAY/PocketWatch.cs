using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class PocketWatch : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject GameSlider;

    public SliderGameLogic sliderGame; //Field to link the game to so it knows what to listen to
    public bool watchActive = false; //As it says
    private bool Zoned = false;

    void Update()
    {
        if (watchActive && Zoned && Input.GetKeyDown(KeyCode.T))
        {
            bool success = sliderGame.Result();
            if (success)
            {
                SceneManager.LoadScene("TheHall");
            }
            else
            {
                SceneManager.LoadScene("Wrong");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            Zoned = true;
            if (watchActive)
            {
                GameSlider.SetActive(true);
                print("DoorTriggered.");
            }

            else
            {
                print("Error: GameSlider slot is Empty.");
            }
        }
        else if (other.CompareTag("Room")) // If detects the trigger barrier for no, it will remove all possibility of Zoned and GameSlider
        {
            Zoned = false;
            if (watchActive)
            {
                GameSlider.SetActive(false);
                print("DoorTriggered OFF.");
            }
        }
    }
}
