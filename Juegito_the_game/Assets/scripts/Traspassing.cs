using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traspassing : MonoBehaviour{

    public GameObject Player1;
    public GameObject Player2;


    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.name == "Player1")
            Player1 = collision.gameObject;

        if (collision.gameObject.name == "Player2")
            Player2 = collision.gameObject;
        
    }

    IEnumerator WaitForCollider1(){

        // suspend execution for 1 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player1.GetComponent<Collider2D>(), false);

    }

    IEnumerator WaitForCollider2(){

        // suspend execution for 1 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>(), false);

    }

    // Update is called once per frame
    void Update (){
               
        if (Input.GetButtonDown("P1_XboxA") && Input.GetAxis("P1_LeftJoyY") == -1){

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player1.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider1());

        }

        if (Input.GetButtonDown("P2_XboxA") && Input.GetAxis("P2_LeftJoyY") == -1){

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player2.GetComponent<Collider2D>(), true);
            StartCoroutine(WaitForCollider2());

        }
    }
}
