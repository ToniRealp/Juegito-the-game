using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSize : MonoBehaviour {
    public float charge;
    public float ultCharge;
    public float rtButton;
    public float ltButton;
    private bool growingS = false;
    private bool growingU = false;

    void Update () {
        charge = GetComponentInParent<Shoot>().shotCharge;
        ultCharge = GetComponentInParent<Shoot>().ltDown;
        rtButton = GetComponentInParent<InputManger>().rt;
        ltButton = GetComponentInParent<InputManger>().lt;

        if (ultCharge < 1.5 && ltButton !=0 && !growingS)
        {
            growingU = true;
            GetComponent<Transform>().transform.localScale = GetComponent<Transform>().transform.localScale + new Vector3(ultCharge / 7, ultCharge / 7, 0);
        }
        if (charge < 1 && rtButton != 0 && !growingU)
        {
            growingS = true;
            GetComponent<Transform>().transform.localScale = GetComponent<Transform>().transform.localScale + new Vector3(charge / 14, charge / 14, 0);
        }

        if (ltButton == 0 && rtButton == 0) {
            growingU = growingS = false;
            GetComponent<Transform>().transform.localScale = new Vector3(1.25f, 1.25f, 0);
        }
    }
}
