using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour {

    float timer;
    public GameController gC;
    int minutes;
    int seconds;
	
	void Update () {


        timer = gC.gameTimer;

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;

        if (gC.suddenDeath == false)
        {

            if (timer > 0 && !gC.gameOver)
            {

                if (seconds > 9)
                    GetComponent<TextMeshProUGUI>().text = minutes.ToString() + ":" + seconds.ToString();

                if (seconds <= 9)
                    GetComponent<TextMeshProUGUI>().text = minutes.ToString() + ":0" + seconds.ToString();

            }
            else if (timer <= 0 || gC.gameOver)
            {
                GetComponent<TextMeshProUGUI>().text = "FINISH!";
            }
        } else
        {
            GetComponent<TextMeshProUGUI>().text = "SUDDEN DEATH!!!";
        }
    }
}
