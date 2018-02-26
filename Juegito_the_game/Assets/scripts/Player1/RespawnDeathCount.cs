using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDeathCount : MonoBehaviour{

    public int deaths = 0;
    public bool die = false;
    public bool lastHit = false;
    public GameObject lastHitMe;


    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Limits"){

            deaths = deaths + 1;
            die = true;

        }

        if (collision.gameObject.tag == "Bullet"){

            lastHitMe = collision.gameObject.GetComponent<BallMovement2>().player;
            lastHit = true;

        }  
    }
	
	void Update (){

        if (die){

            GetComponent<Rigidbody2D>().transform.position = new Vector2(0,3.2f);
            die = false;

            if(lastHit)
            lastHitMe.GetComponent<Shoot2>().ultCharge += 33;

            lastHit = false;

        } 
	}
}
