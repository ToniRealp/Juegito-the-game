using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    Text num;
    float time = 4;

    void Start () {
        num = GetComponent<Text>();
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
