using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfMovement : MonoBehaviour {

    public enum Movement { BackAndForth, rotate };
    public Movement myMovement;
    public Vector2 maxPos;
    public Vector2 minPos;
    public float speed;
    private bool going = true;
    private Rigidbody2D plat1;
    private Rigidbody2D plat2;
    private Vector3 rad;
    float a = 0;

    void Start () {
        plat1 = gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
        plat2 = gameObject.transform.GetChild(1).GetComponent<Rigidbody2D>();
        rad = plat1.transform.position - transform.position;
    }
	
	void FixedUpdate () {
        switch (myMovement)
        {
            case Movement.BackAndForth:
                if (GetComponent<Transform>().transform.position.x < minPos.x)
                    going = true;
                else if (GetComponent<Transform>().transform.position.x > maxPos.x)
                    going = false;

                if (going)
                    GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);

                else
                    GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
                break;

            case Movement.rotate:
                float xPos = gameObject.transform.position.x + rad.magnitude * Mathf.Cos(a * Mathf.PI / 180.0f);
                float yPos = gameObject.transform.position.y + rad.magnitude * Mathf.Sin(a * Mathf.PI / 180.0f);
                Vector3 targget1 = new Vector3(xPos, yPos, 0);
                targget1 = targget1 - plat1.transform.position;
                plat1.velocity = targget1;

                xPos = gameObject.transform.position.x + rad.magnitude * Mathf.Cos((a + 180) * Mathf.PI / 180.0f);
                yPos = gameObject.transform.position.y + rad.magnitude * Mathf.Sin((a + 180) * Mathf.PI / 180.0f);
                Vector3 targget2 = new Vector3(xPos, yPos, 0);
                targget2 = targget2 - plat2.transform.position;
                plat2.velocity = targget2;
                a++;
                break;
        }
    }
}
