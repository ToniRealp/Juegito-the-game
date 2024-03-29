﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDeathCount : MonoBehaviour{

    public GameObject lastHitMe;
    public int deaths = 0;
    public bool die = false;
    public bool lastHit = false;
    public string myPlayer;
    public float timer;



    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Limits"){

            deaths = deaths + 1;
            gameObject.GetComponent<Shoot>().ultCharge -= 20;
            if(gameObject.GetComponent<Shoot>().ultCharge < 0)
                gameObject.GetComponent<Shoot>().ultCharge = 0;
            die = true;

        }

        if (collision.gameObject.tag == "Bullet"){

            if(collision.gameObject.GetComponent<BallMovement>().player.name != myPlayer){ 
                lastHitMe = collision.gameObject.GetComponent<BallMovement>().player;
                lastHit = true;
                StartCoroutine(Reset(3));
            }
        }  
    }
	
	void Update (){

        if (die){

            GetComponent<Rigidbody2D>().transform.position = new Vector2(0,3.2f);
            die = false;
            timer = 2f;
            gameObject.layer=13;
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);

            if(lastHit)
            lastHitMe.GetComponent<Shoot>().ultCharge += 33;

            lastHit = false;

        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            gameObject.layer = 9;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    IEnumerator Reset(float toWait)
    {
        yield return new WaitForSeconds(toWait);
        lastHitMe = null;
        lastHit = false;

    }
}
