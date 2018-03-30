using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour {

    public string playerNumber;
    public Animator animator;
    public Animator shieldAnimator;
    public float xAxis;
    public bool shielded;
    

    void Start() {

        animator = GetComponent<Animator>();

    }

    void Update () {

        shielded = GetComponentInChildren<Shield>().shielded;
        Movement();
        Jump();
        Crouch();
        Shield();
        xAxis = Mathf.Abs(Input.GetAxis(playerNumber + "LeftJoyX"));
    }

    private void Movement() {

        
        
        if (Input.GetAxis(playerNumber + "LeftJoyX") > 0.4f && Input.GetButton(playerNumber + "LB")==false && !shielded || Input.GetAxis(playerNumber + "LeftJoyX") < -0.4f && Input.GetButton(playerNumber + "LB")==false && !shielded)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("movementSpeed", xAxis);
        }
       
        else { animator.SetBool("isMoving", false); }

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

    private void Shield()
    {
        if (shielded)
            shieldAnimator.SetBool("shield", true);
        else shieldAnimator.SetBool("shield", false);

    }
    
}