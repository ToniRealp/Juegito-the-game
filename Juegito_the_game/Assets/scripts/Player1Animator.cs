using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour {

    public string playerNumber;
    public Animator animator;
    public float xAxis;

    void Start() {

        animator=GetComponent<Animator>();
        
    }

    void Update () {
        Movement();
        Jump();
        xAxis = Mathf.Abs(Input.GetAxis(playerNumber + "LeftJoyX"));
    }

    private void Movement() {

        if (Input.GetAxis(playerNumber + "LeftJoyX") > 0.4f && Input.GetButton(playerNumber + "LB") == false || Input.GetAxis(playerNumber + "LeftJoyX") < -0.4f && Input.GetButton(playerNumber+"LB")==false)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("movementSpeed",xAxis );
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

    
}