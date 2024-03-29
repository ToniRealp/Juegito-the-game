﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traspassing : MonoBehaviour{

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;


    void Start(){
    
        Player1 = GameObject.Find("Player1");
        
        Player2 = GameObject.Find("Player2");

        Player3 = GameObject.Find("Player3");

        Player4 = GameObject.Find("Player4");

    }

    IEnumerator WaitForCollider1(){

        // suspend execution for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player1.GetComponent<Collider2D>(), false);

    }

    IEnumerator WaitForCollider2(){

        // suspend execution for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>(), false);

    }

    IEnumerator WaitForCollider3()
    {

        // suspend execution for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player3.GetComponent<Collider2D>(), false);

    }

    IEnumerator WaitForCollider4()
    {

        // suspend execution for 0.2 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player4.GetComponent<Collider2D>(), false);

    }

    void Update (){
               
        if (Input.GetButtonDown("P1_XboxA") && Input.GetAxis("P1_LeftJoyY") == -1){

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player1.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider1());

        }

        if (Input.GetButtonDown("P2_XboxA") && Input.GetAxis("P2_LeftJoyY") == -1){

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider2());

        }

        if (Input.GetButtonDown("P3_XboxA") && Input.GetAxis("P3_LeftJoyY") == -1)
        {

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player3.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider3());

        }

        if (Input.GetButtonDown("P4_XboxA") && Input.GetAxis("P4_LeftJoyY") == -1)
        {

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player4.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider4());

        }
    }
}
