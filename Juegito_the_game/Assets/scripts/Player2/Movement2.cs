using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float leftJoystickY;
    public float leftJoystickX;
    public int velocity;
    public bool onFloor2;
    public int jumpForce;
    public int onAirVelocity;
    float leavingTheGround;
    public int side;
    private bool facingRight2;
    private bool grounded2;
    private bool jumping2;
    public string playerNumber;

    private void Start()
    {
        side = 1;
        facingRight2 = true;
    }

    private void Update()
    {
        leftJoystickY = Input.GetAxis(playerNumber+"LeftJoyY");
        leftJoystickX = Input.GetAxis(playerNumber+"LeftJoyX");
        GetInput();
    }

    void FixedUpdate()
    {

        
        PlayerMovementXaxis();
        PlayerJump();
        PlayerFlip(leftJoystickX);
        ResetValues();

    }



    void PlayerMovementXaxis()
    {
        if (!grounded2)
        {

            if (onFloor2) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity * leftJoystickX, 0));
                }
            else {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(onAirVelocity * leftJoystickX, 0));

            }
        }

        if (leftJoystickX > 0)
            side = 1;
        if (leftJoystickX < 0)
            side = -1;



        
    }

    void PlayerJump()
    {
        
        if (jumping2 && onFloor2 && Input.GetAxis(playerNumber+"LeftJoyY") != -1)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            leavingTheGround = leftJoystickX;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
        {
            onFloor2 = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor2 = false;
        }
    }

    void PlayerFlip(float leftJoyX)
    {
        if (leftJoyX > 0 && !facingRight2 || leftJoyX < 0 && facingRight2)
        {
            facingRight2 = !facingRight2;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
         
    }

    void GetInput()
    {
        if (Input.GetButtonDown(playerNumber+"LB"))
        {
            grounded2 = true;
        }
        else if (Input.GetButtonUp(playerNumber+"LB"))
        {
            grounded2 = false;
        }

        if (Input.GetButtonDown(playerNumber+"XboxA"))
        {
            jumping2 = true;
        }
    }

    void ResetValues()
    {
        jumping2 = false;
    }
}