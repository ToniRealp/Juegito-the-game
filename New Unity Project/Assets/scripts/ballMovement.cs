using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D otherRb;
    public float speed;
    private Vector2 direction;
    private float charge;
    private float maxCharge;
    private Vector2 force;
    private int ult;

    void Awake () {
        direction = GameObject.Find("ThePlayer").GetComponent<shoot>().DirectionJoyL;
        charge = GameObject.Find("ThePlayer").GetComponent<shoot>().shotCharge;
        maxCharge = GameObject.Find("ThePlayer").GetComponent<shoot>().maxCharge;
        rb = GetComponent<Rigidbody2D>();
        ult = GameObject.Find("ThePlayer").GetComponent<shoot>().ultCharge;

        if (ult < 10)
            ult = 10;

        transform.localScale = new Vector3(1, 1, 0) * (charge / maxCharge) * (ult / 10);

        if ((1 * (charge / maxCharge) * (ult / 10)) > 0.7f) {
            transform.localScale = new Vector3(1, 1, 0) * 0.7f;
        }
        

        if (charge < 0.3)
            charge = 0.3f;

        force = (direction * speed * charge * (ult / 10));
        rb.AddForce(force);
    }

        // Update is called once per frame
        void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name != "ThePlayer") { 
            if (other.gameObject.tag == "Player"){
                if(GameObject.Find("ThePlayer").GetComponent<shoot>().ultCharge < 100)
                    GameObject.Find("ThePlayer").GetComponent<shoot>().ultCharge += 2;

                otherRb = other.gameObject.GetComponent<Rigidbody2D>();
                otherRb.AddForce(force);
                Destroy(gameObject);
            }
        }
    }
}
