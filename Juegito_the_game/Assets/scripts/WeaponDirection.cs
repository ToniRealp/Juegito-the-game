using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDirection : MonoBehaviour {

    Transform armTransform;
    Vector2 directionVec;
    Vector2 standardVec;
    public float direction;
    public bool facingRight;
    //Input
    private float xAxis;
    public float yAxis;

    void Start () {

        armTransform = GetComponent<Transform>();
        standardVec = new Vector2(1, 0);

    }
	
	void Update () {

        InputManagerScript();

        if (yAxis == 0 && xAxis == 0 && facingRight == false)
            direction =0;
        else if (yAxis == 0 && xAxis == 0 && facingRight == true)
            direction = -180;
        else if (yAxis < 0)
            direction = -Vector2.Angle(directionVec, standardVec);
        else
            direction = Vector2.Angle(standardVec, directionVec);
        
        armTransform.eulerAngles = new Vector3(0, 0, direction);

        PlayerFlip(-xAxis);
       
	}

    void PlayerFlip(float leftJoyX)
    {

        if (leftJoyX > 0 && !facingRight || leftJoyX < 0 && facingRight)
        {

            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            scale.y *= -1;
            transform.localScale = scale;

        }
    }

    void InputManagerScript()
    {
        
        xAxis = GetComponentInParent<InputManger>().leftJoystickX;
        yAxis = GetComponentInParent<InputManger>().leftJoystickY;
        directionVec = new Vector2(xAxis, yAxis);

    }
}
