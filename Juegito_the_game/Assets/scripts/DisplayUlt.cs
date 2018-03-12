using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisplayUlt : MonoBehaviour {

    TextMesh UltCharge;
    public GameObject player;

	void Start () {
        UltCharge = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        UltCharge.text = player.GetComponent<Shoot>().ultCharge + "%";
        transform.position = player.transform.position + new Vector3 (0.6f, 1.2f, 0);
	}
}
