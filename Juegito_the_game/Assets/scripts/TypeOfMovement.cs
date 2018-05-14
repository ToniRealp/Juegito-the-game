using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfMovement : MonoBehaviour {

    public enum Movement { BackAndForth, rotate };
    public Movement myMovement;
    public Vector2 maxPos;
    public Vector2 minPos;
    private bool going = true;

    void Start () {
		
	}
	
	void Update () {
        if (GetComponent<Traspassing>().transform.position.x < minPos.x)
            going = true;
        else if (GetComponent<Traspassing>().transform.position.x > maxPos.x)
            going = false;

        if (going)
            GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);
            
        else
            GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0);
    }
}
