using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Death_Count2 : MonoBehaviour {

    public int deaths = 0;
    public bool die = false;
    public bool lastHit = false;
    public GameObject lastHitMe;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Limits"){ 
            deaths = deaths + 1;
            die = true;
        }

        if (collision.gameObject.tag == "Bullet") {
            lastHitMe = collision.gameObject.GetComponent<ballMovement>().player;
            lastHit = true;
        }

        
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (die)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(0,3.2f);
            die = false;

            if(lastHit)
            lastHitMe.GetComponent<shoot>().ultCharge += 33;
            lastHit = false;
        } 


	}
}
