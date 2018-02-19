using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D otherRb;
    public float speed;
    public float k;
    private Vector2 direction;
    private float charge;
    private float maxCharge;
    private Vector2 force;
    private int ult;
    private float size;

    void Awake () {
        direction = GameObject.Find("ThePlayer").GetComponent<shoot>().DirectionJoyL;
        charge = GameObject.Find("ThePlayer").GetComponent<shoot>().shotCharge;
        maxCharge = GameObject.Find("ThePlayer").GetComponent<shoot>().maxCharge;
        rb = GetComponent<Rigidbody2D>();
        ult = GameObject.Find("ThePlayer").GetComponent<shoot>().ultCharge;

        calculateSize();

        if (charge < 0.3)
            charge = 0.3f;

        force = (direction * (speed + ((10 * ult) + (k * charge))));
        rb.AddForce(force);
    }

        // Update is called once per frame
        void Update () {
        
	}

    void calculateSize()
    {
        size = ((((50 * charge) + (ult / 2)) / (maxCharge * 100)) * 0.5f);

        if (size < 0.05f)
            size = 0.05f;

        transform.localScale = new Vector3(1, 1, 0) * size;

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
