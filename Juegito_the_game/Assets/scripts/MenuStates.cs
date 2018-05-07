using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStates : MonoBehaviour {

    private int state;
    private GameObject myEventSystem;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject charMenu;
    public GameObject levelMenu;
    public GameObject levelMenuSing;

    public GameObject singlePB;
    public GameObject twoPPB;
    public GameObject optPB;
    public GameObject multiPB;

    // Use this for initialization
    void Start () {
        state = 0;
        myEventSystem = GameObject.Find("EventSystem");
        //myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
	
	// Update is called once per frame
	void Update () {

        if (mainMenu.activeSelf)
        {
            state = 0;
        }
        if (optionsMenu.activeSelf)
        {
            state = 1;
        }
        if (charMenu.activeSelf)
        {
            state = 2;
        }
        if (levelMenu.activeSelf)
        {
            state = 3;
        }
        if (levelMenuSing.activeSelf)
        {
            state = 4;
        }


    
        if (state == 1)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(optPB);
            }
        }
        if (state == 2)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                charMenu.SetActive(false);
                mainMenu.SetActive(true);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(multiPB);
            }
        }
        if (state == 3)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                levelMenu.SetActive(false);
                charMenu.SetActive(true);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(twoPPB);
            }
        }
        if (state == 4)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                levelMenuSing.SetActive(false);
                mainMenu.SetActive(true);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(singlePB);
            }
        }
    }
}
