using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public float leftJoystickY;
    public float leftJoystickX;
    public int velocity;
    public bool onFloor;
    public int jumpForce;
    public int onAirVelocity;
    float leavingTheGround;
    public int side;
    private bool facingRight;
    private bool grounded;
    private bool jumping;
    public string playerNumber;


    void Start(){

        side = 1;
        facingRight = true;

    }

    void Update(){

        leftJoystickY = Input.GetAxis(playerNumber+"LeftJoyY");
        leftJoystickX = Input.GetAxis(playerNumber+"LeftJoyX");
        GetInput();

    }

    void FixedUpdate(){
        
        PlayerMovementXaxis();
        PlayerJump();
        PlayerFlip(leftJoystickX);
        ResetValues();

    }



    void PlayerMovementXaxis(){

        if (!grounded){

            if (onFloor)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity * leftJoystickX, 0));
                
            else 
                GetComponent<Rigidbody2D>().AddForce(new Vector2(onAirVelocity * leftJoystickX, 0));

        }

        if (leftJoystickX > 0)
            side = 1;

        if (leftJoystickX < 0)
            side = -1;

    }

    void PlayerJump(){
        
        if (jumping && onFloor && Input.GetAxis(playerNumber+"LeftJoyY") != -1){

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            leavingTheGround = leftJoystickX;

        }
    }

    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
            onFloor = true;

    }

    void OnCollisionExit2D(Collision2D collision){

        if (collision.gameObject.tag == "Floor")
            onFloor = false;
        
    }

    void PlayerFlip(float leftJoyX){

        if (leftJoyX > 0 && !facingRight || leftJoyX < 0 && facingRight){

            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }   
    }

    void GetInput(){

        if (Input.GetButtonDown(playerNumber+"LB"))
            grounded = true;
        
        else if (Input.GetButtonUp(playerNumber+"LB"))
            grounded = false;

        if (Input.GetButtonDown(playerNumber+"XboxA"))
            jumping = true;
        
    }

    void ResetValues(){

        jumping = false;

    }
}