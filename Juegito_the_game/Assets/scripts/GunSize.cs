using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSize : MonoBehaviour {
    public float charge;
    float recover = 0;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame  
	void Update () {
        charge = transform.parent.GetComponentInParent<Shoot>().shotCharge;
        if (charge < 1) { 
            GetComponent<Transform>().transform.localScale = GetComponent<Transform>().transform.localScale + new Vector3(charge/16, charge/16, 0);
            recover += charge / 8;
        }
        if (charge == 0) { 
            GetComponent<Transform>().transform.localScale = new Vector3(1.25f, 1.25f, 0);
            recover = 0;
        }
    }
}
