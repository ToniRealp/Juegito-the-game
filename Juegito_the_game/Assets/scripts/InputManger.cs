using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{

    public string playerNumber;
    public float leftJoystickY;
    public float leftJoystickX;
    public float rt;
    public float lt;
    public bool pauseButton;
    public bool a;
    public bool x;
    public bool y;
    public bool b;
    public bool lb;
    public bool lbUp;
    public bool rb;
    public bool XboxLbNd;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        leftJoystickY = Input.GetAxis(playerNumber + "LeftJoyY");
        leftJoystickX = Input.GetAxis(playerNumber + "LeftJoyX");
        rt = Input.GetAxis(playerNumber + "RT");
        lt = Input.GetAxis(playerNumber + "LT");
        XboxA();
        XboxX();
        XboxY();
        XboxB();
        XboxLb();
        XboxLbUp();
        XboxLbNotdown();
        Pause();

    }

    void XboxA()
    {
        if (Input.GetButtonDown(playerNumber + "XboxA"))
            a = true;
        else
            a = false;
    }

    void XboxX()
    {
        if (Input.GetButtonDown(playerNumber + "XboxX"))
            x = true;
        else
            x = false;
    }

    void XboxY()
    {
        if (Input.GetButtonDown(playerNumber + "XboxY"))
            y = true;
        else
            y = false;
    }

    void XboxLb()
    {
        if (Input.GetButtonDown(playerNumber + "LB"))
            lb = true;
        else
            lb = false;
    }

    void XboxLbUp()
    {
        if (Input.GetButtonUp(playerNumber + "LB"))
            lbUp = true;
        else
            lbUp = false;
    }

    void XboxLbNotdown()
    {
        if (Input.GetButton(playerNumber + "LB"))
            XboxLbNd = true;
        else
            XboxLbNd = false;
    }

    void XboxB()
    {
        if (Input.GetButtonDown(playerNumber + "XboxB"))
            b = true;
        else
            b = false;
    }

    void Pause()
    {
        if (Input.GetButtonDown(playerNumber + "XboxP"))
        {
            pauseButton = true;
            Debug.Log("pause");
        }
        else
            pauseButton = false;
    }
}
