
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonCamera : MonoBehaviour
{


    public float xAxis;
    public float yAxis;


    private float xAxisTurnRate = 300f;
    private float yAxisTurnRate = 300f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Hides coursor
    }


    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None; //Shows coursor again
    }


    void LateUpdate() //Called every frame after Update method finishes
    {
        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0f);


        Camera.main.transform.rotation = newRotation;
    }


    public void AddXAxisInput(float input)
    {
        xAxis -= input * xAxisTurnRate; //makes it move in time line
        xAxis = Mathf.Clamp(xAxis, -80f, 80f); //Clamp retraint
    }


    public void AddYAxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
}