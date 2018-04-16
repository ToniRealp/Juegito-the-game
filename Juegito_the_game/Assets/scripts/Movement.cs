using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{

    public float leftJoystickY;
    public float leftJoystickX;
    float leavingTheGround;
    public int velocity;
    public int jumpForce;
    public int dashForce;
    public int onAirVelocity;
    public int side;
    public bool facingRight;
    public bool grounded;
    private bool jumping;
    public bool onFloor;
    public float venom;
    //public string playerNumber;


    void Start(){

        side = 1;
        venom = 1f;
        facingRight = true;
    }

    void Update(){

        leftJoystickY = GetComponent<InputManger>().leftJoystickY;
        leftJoystickX = GetComponent<InputManger>().leftJoystickX;
        GetInput();

        if (venom == -1)
            StartCoroutine(WaitAndNormal(5));

    }

    void FixedUpdate(){
        
        PlayerMovementXaxis();
        PlayerJump();
        PlayerFlip(leftJoystickX);
        PlayerDash();
        ResetValues();

    }

    void PlayerMovementXaxis(){

        if (!grounded){

            if (onFloor)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(((velocity * leftJoystickX) * venom), 0));
                
            else 
                GetComponent<Rigidbody2D>().AddForce(new Vector2((onAirVelocity * leftJoystickX * venom), 0));

        }

        if (leftJoystickX > 0)
            side = 1;

        if (leftJoystickX < 0)
            side = -1;

    }

    void PlayerJump(){
        
        if (jumping && onFloor && GetComponent<InputManger>().leftJoystickY != -1){

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            leavingTheGround = leftJoystickX;
            
        }
    }

    bool dashed = false;

    void PlayerDash()
    {
        if (GetComponent<InputManger>().b && !onFloor && !dashed)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(leftJoystickX * dashForce, leftJoystickY * dashForce * 3 / 2));
            dashed = true;
        }

        if (onFloor)
            dashed = false;
    }

    void OnCollisionStay2D(Collision2D collision){

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

        if (GetComponent<InputManger>().lb)
            grounded = true;
        else if(GetComponent<InputManger>().lbUp)
            grounded = false;

        if (GetComponent<InputManger>().a)
            jumping = true;

        if (GetComponent<InputManger>().y) {
            GetComponent<EffectsManager>().current = GetComponent<EffectsManager>().next;
            GetComponent<EffectsManager>().next = EffectsManager.Effect.None;
        }
    }

    void ResetValues(){

        jumping = false;

    }

    IEnumerator WaitAndNormal(float toWait)
    {
        yield return new WaitForSeconds(toWait);
        venom = 1;
    }
}
