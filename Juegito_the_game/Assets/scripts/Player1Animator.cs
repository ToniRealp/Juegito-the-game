using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour {

    public string playerNumber;
    public Animator animator;
    public float xAxis;

    private float shieldDuration = 1f;
    private float shieldCooldown = 5f;
    private float timer = 5f;
    private float timer2;
    private bool shielded;
    private bool isCheck = false;

    void Start() {
        shielded = false;
        animator=GetComponent<Animator>();
        
    }

    void Update () {
      
        Movement();
        Jump();
        Crouch();
        xAxis = Mathf.Abs(Input.GetAxis(playerNumber + "LeftJoyX"));
    }

    private void Movement() {

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if ((shielded == false)&&Input.GetAxis(playerNumber + "LeftJoyX") > 0.4f && Input.GetButton(playerNumber + "LB") == false || Input.GetAxis(playerNumber + "LeftJoyX") < -0.4f && Input.GetButton(playerNumber+"LB")==false)
        {
            if (shielded == false)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("movementSpeed", xAxis);
            }
        }
        else { animator.SetBool("isMoving", false); }

        if (timer > shieldCooldown && Input.GetButtonDown(playerNumber + "XboxX"))
        {
            shielded = true;
            animator.SetBool("isMoving", false);
            timer = 0f;
        }

        if (shielded == true)
        {

            if (isCheck == false)
            {
                isCheck = true;
                timer2 = 0f;
            }

            if (timer2 > shieldDuration)
            {
                shielded = false;
                isCheck = false;
            }
        }

    }

    bool flag = true;

    private void Jump() {

        if (!GetComponent<Movement>().onFloor && flag)
        {
            animator.SetBool("onAir", true);
            flag = false;
        }
        if (GetComponent<Movement>().onFloor && !flag)
        {
            animator.SetBool("onAir", false);
            flag = true;
        }

    }

    private void Crouch()
    {
        if (Input.GetAxis(playerNumber + "LeftJoyY") == -1)
            animator.SetBool("crouched", true);
        else animator.SetBool("crouched", false);

    }

    
}