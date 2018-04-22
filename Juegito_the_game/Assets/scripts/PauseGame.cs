using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseGame : MonoBehaviour {

    InputManger im;
    public GameController gc;
    public GameObject pausePanel;

	// Use this for initialization
	void Start () {
        im = GetComponent<InputManger>();
	}
	
	// Update is called once per frame
	void Update () {
        Pause();
	}

    void Pause()
    {
        if (im.pauseButton)
        {
            if (gc.waitOver)
            {
                if (gc.paused)
                {
                    pausePanel.SetActive(false);
                    gc.paused = false;
                }
                else
                {
                    pausePanel.SetActive(true);
                    gc.paused = true;
                }
            }
        }

        if (gc.waitOver)
        {
            if (gc.paused)
            {
                if (im.a)
                {
                    SceneManager.LoadScene("Menu");
                }
                if (im.b)
                {
                    pausePanel.SetActive(false);
                    gc.paused = false;
                }
            }
        }
    }

}
