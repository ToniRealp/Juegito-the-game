using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSize : MonoBehaviour {
    public float charge;
    public float ultCharge;
    public float rtButton;
    public float ltButton;

	void Update () {
        charge = GetComponentInParent<Shoot>().shotCharge;
        ultCharge = GetComponentInParent<Shoot>().ltDown;
        rtButton = GetComponentInParent<InputManger>().rt;
        ltButton = GetComponentInParent<InputManger>().lt;

        if (charge < 1 && rtButton !=0 ) { 
            GetComponent<Transform>().transform.localScale = GetComponent<Transform>().transform.localScale + new Vector3(charge / 16, charge / 16, 0);
        }

        if (ultCharge < 1.5 && ltButton !=0)
        {
            GetComponent<Transform>().transform.localScale = GetComponent<Transform>().transform.localScale + new Vector3(ultCharge / 16, ultCharge / 16, 0);
        }

        if (ltButton == 0 && rtButton == 0) { 
            GetComponent<Transform>().transform.localScale = new Vector3(1.25f, 1.25f, 0);
        }
    }
}
