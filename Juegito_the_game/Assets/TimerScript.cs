using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour {

    float timer;
    public GameController gC;
	
	void Update () {


        timer = gC.gameTimer;
        GetComponent<TextMeshProUGUI>().text = timer.ToString();


	}
}
