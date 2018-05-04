using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    TextMesh num;
    float time = 4;

    void Start () {
        num = GetComponent<TextMesh>();
        num.text = 3 + "";
    }
	
	// Update is called once per frame
	void Update () {
        num.text = (int)time + "";

        if (time < 1){
            num.text = "FIGHT!";
        }
        if (time <= 0){
            gameObject.SetActive(false);
        }

        time -= Time.deltaTime;

    }
}
