using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

    public GameObject refPlayer;
    public Vector2 playerPos;
    public Camera refCam;
    public Vector2 camPos;
    public float height;
    public float width;
	// Use this for initialization
	void Start () {
        getPositions();
    }
	
	// Update is called once per frame
	void Update () {
        getPositions();

        if (playerPos.x > camPos.x + width)
        {
            transform.position = new Vector2(camPos.x + width , playerPos.y);
        }

        if(playerPos.x< camPos.x - width)
        {
            transform.position = new Vector2(camPos.x-width, playerPos.y);
        }

        if (playerPos.y > camPos.y + height)
        {
            transform.position = new Vector2(playerPos.x, camPos.y+height);
        }

        if (playerPos.y < camPos.y - height)
        {
            transform.position = new Vector2(playerPos.x, camPos.y-height);
        }
        else
            transform.position = (playerPos);
    }

    void getPositions()
    {
        playerPos = refPlayer.GetComponent<Transform>().position;
        float height = 2f * refCam.orthographicSize;
        float width = height * refCam.aspect;
        camPos = refCam.GetComponent<Transform>().position;
    }
}
