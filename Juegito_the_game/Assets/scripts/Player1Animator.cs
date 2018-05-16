using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour {

    public Animator animator;
    public Animator shieldAnimator;
    public Animator weaponAnimator;
    public bool shielded;
    public Transform ult;

    //Input
    public bool XboxLbNd;
    public float leftJoystickY;
    public float leftJoystickX;
    public float xAxis;


    void Start() {

        animator = GetComponent<Animator>();
        ult = transform.GetChild(2);

    }

    void Update () {

        InputContollerScript();

        Movement();
        Jump();
        Crouch();
        Shield();
        UltAnimation();
        WeaponAnimation();
        xAxis = Mathf.Abs(leftJoystickX);

    }

    private void Movement() {

        if (leftJoystickX > 0.4f && XboxLbNd == false || leftJoystickX < -0.4f && XboxLbNd==false)
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
        if (leftJoystickY == -1)
            animator.SetBool("crouched", true);
        else animator.SetBool("crouched", false);

    }

    private void Shield()
    {
        if (shielded)
            shieldAnimator.SetBool("shield", true);
        else shieldAnimator.SetBool("shield", false);

    }

    private void UltAnimation()
    {
        if(gameObject.GetComponent<Shoot>().ultCharge==100)
        ult.gameObject.SetActive(true);
        else ult.gameObject.SetActive(false);

    }

    private void WeaponAnimation() {
        if (gameObject.GetComponent<Shoot>().ltDown > 0)
            weaponAnimator.SetBool("isCharging", true);
        else weaponAnimator.SetBool("isCharging", false);

    }

    private void InputContollerScript()
    {

        shielded = GetComponentInChildren<Shield>().shielded;
        XboxLbNd = GetComponent<InputManger>().XboxLbNd;
        leftJoystickX = GetComponent<InputManger>().leftJoystickX;
        leftJoystickY = GetComponent<InputManger>().leftJoystickY;

    }
    
}