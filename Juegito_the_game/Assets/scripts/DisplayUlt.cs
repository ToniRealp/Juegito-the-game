using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayUlt : MonoBehaviour {

    
    Text UltCharge;
    public GameObject player;

	void Start () {
        UltCharge = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
            UltCharge.text = player.GetComponent<Shoot>().ultCharge.ToString();
        else
            UltCharge.text = "KO";
        //transform.position = player.transform.position + new Vector3 (0.6f, 1.2f, 0);
    }
}
