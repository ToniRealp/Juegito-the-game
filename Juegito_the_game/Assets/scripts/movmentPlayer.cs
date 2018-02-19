using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movmentPlayer : MonoBehaviour {

    public int x, y, grav=0;
    public int speed,acceleration;
    public Rigidbody2D rb;

    public GameObject referencedObject;
    floorScript referencedScript;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	
	void Update () {
		
        if (Input.GetKey("a") && x > -20)
        {
            x = x - speed*acceleration;
        }

        if (Input.GetKey("d") && x < 20)
        {
            x = x + speed * acceleration;
        }

        if (Input.GetButtonDown("Jump"))
        {
            y = y + speed * acceleration*30;
            referencedScript = referencedObject.GetComponent<floorScript>();
            referencedScript.inside = false;
        }

            

        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            if (x < 0)
            {
                x = x + acceleration;
            }
            if (x > 0)
            {
                x = x - acceleration;
            }
        }

        if (y != -10)
        {
            y=y-grav;
            grav++;
        }
       
        rb.velocity = new Vector2(x, y);
	} 
}
