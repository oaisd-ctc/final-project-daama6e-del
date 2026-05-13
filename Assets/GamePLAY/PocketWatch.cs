using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            Zoned = true;
            if (watchActive)
            {
                GameSlider.SetActive(true);
                print("DoorTriggered.");
            }
        }
    }
}
