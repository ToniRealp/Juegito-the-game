using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traspassing : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject;
        }

    }

    IEnumerator WaitForCollider()
    {
        // suspend execution for 1 seconds
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>(), false);
    }

    // Update is called once per frame
    void FixedUpdate () {
               
        if (Input.GetButtonDown("XboxA") && Input.GetAxis("LeftJoyY") == -1)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>(), true);

            StartCoroutine(WaitForCollider());
        }
    }
}
