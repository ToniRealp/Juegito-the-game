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
    public GameObject volumeMenu;
    public GameObject displayMenu;
    public GameObject controlsImage;

    public GameObject singlePB;
    public GameObject twoPPB;
    public GameObject optPB;
    public GameObject multiPB;
    public GameObject volumePB;
    public GameObject displayPB;
    public GameObject controlsPB;

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
        if (optionsMenu.activeSelf && (!displayMenu.activeSelf) && (!volumeMenu.activeSelf) && (!controlsImage.activeSelf))
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
        if (volumeMenu.activeSelf)
        {
            state = 5;
        }
        if (displayMenu.activeSelf)
        {
            state = 6;
        }
        if (controlsImage.activeSelf)
        {
            state = 7;
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
        if(state == 5)
        {
            if(Input.GetButtonDown("P1_XboxB"))
            {
                volumeMenu.SetActive(false);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(volumePB);
            }
        }
        if(state == 6)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                displayMenu.SetActive(false);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(displayPB);
            }

        }
        if (state == 7)
        {
            if (Input.GetButtonDown("P1_XboxB"))
            {
                controlsImage.SetActive(false);
                myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(controlsPB);
            }
        }
    }
}
