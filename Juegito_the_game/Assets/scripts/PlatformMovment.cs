using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovment : MonoBehaviour {
    public float timer;
    private float currentT;
    public GameObject PlatformPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentT += Time.deltaTime;
        if(currentT >= timer) {
            GameObject platform = (GameObject)Instantiate(PlatformPrefab, new Vector3(-10, -1.5f, 0), Quaternion.Euler(0, 0, 90));
            platform.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0);
            currentT = 0;

        }
		
	}
}
