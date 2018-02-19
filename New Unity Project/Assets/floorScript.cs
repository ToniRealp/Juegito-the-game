using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorScript : MonoBehaviour
{

    public Rigidbody2D rb;

    public bool inside = false;

    public GameObject referenceObject;
    movmentPlayer referenceScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (inside == false)
        {

            referenceScript = referenceObject.GetComponent<movmentPlayer>();
            referenceScript.grav = 0;
            referenceScript.y = -10;
            inside = true;
        }

    }

    void Update()
    {

    }
}