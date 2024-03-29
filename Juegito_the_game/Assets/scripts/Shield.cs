﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour {

    private GameObject playerObject;
    private Collider2D trigger;
    //public string playerNumber;
    private float timer = 5f;
    private float timer2;
    private float coolDown = 5f;
    private float duration = 3f;
    private bool isCheck;
    public bool shielded;
    Movement movementScript;
    Shoot shootScript;


    // Use this for initialization
    void Start () {
        playerObject = gameObject;
        trigger = GetComponent<Collider2D>();
        trigger.isTrigger = true;
        movementScript = gameObject.GetComponentInParent<Movement>();
        shootScript = gameObject.GetComponentInParent<Shoot>();
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer > coolDown && GetComponentInParent<InputManger>().x)
        {
            trigger.isTrigger = false;
            timer = 0f;
        }

        if (trigger.isTrigger == false)
        {
            shootScript.enabled = false;
            shielded = true;


            if (isCheck == false)
            {
                isCheck = true;
                timer2 = 0f;
            }

            if (timer2 > duration)
            {
                trigger.isTrigger = true;
                isCheck = false;
                shielded = false;
            }
        }
        else
        {
            movementScript.enabled = true;
            shootScript.enabled = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            shootScript.ultCharge += 10;
        }
    }

}
