using System;
using UnityEngine;
using UnityEngine.UI; // If you use a Slider

public class SliderGameLogic : MonoBehaviour
{
    public Slider sliderGame;
    public float speed = 1.5f;
    private bool movingForward = true;

    void Update()
    {
        if (movingForward) sliderGame.value += speed * Time.deltaTime; //slider moves animatedly
        else sliderGame.value -= speed * Time.deltaTime;

        if (sliderGame.value >= 1 || sliderGame.value <= 0)
            movingForward = !movingForward;
    }

    // This is the "Bool Sender"
    public bool Result()
    {
        if (sliderGame.value >= 0.45f && sliderGame.value <= 0.55f) //checks if between margin
        {
            Debug.Log("Result For Pocketwatch returned True");
            return true;
        }
        return false;
    }
}