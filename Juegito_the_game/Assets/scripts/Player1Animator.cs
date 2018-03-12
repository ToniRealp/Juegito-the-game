using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour {

    public string playerNumber;
    public Animator animator;
    public float x;
    public bool check=false;

    void Start() {

        animator=GetComponent<Animator>();

    }

    void Update () {

        x = Input.GetAxis(playerNumber + "LeftJoyX");

        if (Input.GetAxis(playerNumber + "LeftJoyX") != 0)
        {
            check = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            check = false;
        }
	}
}
