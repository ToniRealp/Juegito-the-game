using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float leftJoystickY;
    public float leftJoystickX;
    public int velocity;
    public bool onFloor;
    public int jumpForce;
    public int onAirVelocity;
    float leavingTheGround;
    public int side;

    void FixedUpdate()
    {
        leftJoystickY = Input.GetAxis("LeftJoyY");
        leftJoystickX = Input.GetAxis("LeftJoyX");

        PlayerMovementXaxis();
        PlayerJump();

    }



    void PlayerMovementXaxis()
    {
        if (Input.GetButtonDown("LB")==false)
        {

            if (onFloor)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity * leftJoystickX, 0));

            else if (leftJoystickX < leavingTheGround && leavingTheGround > 0)

                GetComponent<Rigidbody2D>().AddForce(new Vector2(onAirVelocity * leavingTheGround, 0));

            else if (leftJoystickX > leavingTheGround && leavingTheGround < 0)

                GetComponent<Rigidbody2D>().AddForce(new Vector2(onAirVelocity * leavingTheGround, 0));

            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(onAirVelocity * leftJoystickX, 0));
        }

        if (leftJoystickX > 0)
            side = 1;
        if (leftJoystickX < 0)
            side = -1;



        
    }

    void PlayerJump()
    {
        
        if (Input.GetButtonDown("XboxA") && onFloor && Input.GetAxis("LeftJoyY") != -1)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            leavingTheGround = leftJoystickX;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            onFloor = false;
        }
    }
}