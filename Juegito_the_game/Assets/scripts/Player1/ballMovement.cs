using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rb;
    public Rigidbody2D otherRb;
    public float speed;
    public float k;
    private Vector2 direction;
    public float charge;
    private float maxCharge;
    private Vector2 force;
    public int ult;
    private float size;
    

   

    void Awake()
    {
        player = GameObject.Find("Player1");
        direction = player.GetComponent<shoot>().DirectionJoyL;
        charge = player.GetComponent<shoot>().shotCharge;
        maxCharge = player.GetComponent<shoot>().maxCharge;
        rb = GetComponent<Rigidbody2D>();
        ult = player.GetComponent<shoot>().ultCharge;

        if (gameObject.tag != "Ulti")
        {
            calculateSize();
        }

        if (charge < 0.3)
            charge = 0.3f;

        force = (direction * (speed + ((10 * ult) + (k * charge))));
        rb.AddForce(force);
    }

    void calculateSize()
    {
        size = ((((50 * charge) + (ult / 2)) / (maxCharge * 100)) * 0.5f);

        if (size < 0.05f)
            size = 0.05f;

        transform.localScale = new Vector3(1, 1, 0) * size;

    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject != player) { 
            if (other.gameObject.tag == "Player"){
              if(player.GetComponent<shoot>().ultCharge < 100)
                  player.GetComponent<shoot>().ultCharge += 2;

                otherRb = other.gameObject.GetComponent<Rigidbody2D>();
                if (gameObject.tag == "Ulti")
                {
                    Destroy(other.gameObject);
                }
                otherRb.AddForce(force);
                Destroy(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != player)
        {
            if (other.gameObject.tag == "Player")
            {
                if (player.GetComponent<shoot>().ultCharge < 100)

                    otherRb = other.gameObject.GetComponent<Rigidbody2D>();
                if (gameObject.tag == "Ulti")
                {
                    Destroy(other.gameObject);
                }
                otherRb.AddForce(force);
                Destroy(gameObject);
            }
        }
    }
}
