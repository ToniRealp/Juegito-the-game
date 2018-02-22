using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private int numPlayers;
    private Transform[] playersT = new Transform[4];
    private GameObject[] players = new GameObject[4];
    private Vector3 mid = new Vector3(0, 0, 0);
    private float separation = 0;
    public float maxY;
    public float minY;

    public float cameraSpeed;
    public float Yoffset;
    public float sizeOfsset;
    public float maxSize;
    public float minSize;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        numPlayers = players.Length;
        updatePlayers();
        cameraPosition();
        float movement = cameraSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mid + new Vector3(0, Yoffset, -1), movement);

    }

    private void FixedUpdate()
    {
        
    }

    void updatePlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < numPlayers; i++)
        {
            playersT[i] = players[i].transform; 
        }
    }

    float Ycenter()
    {
        maxY = playersT[0].position.y;
        minY = playersT[0].position.y;
        for (int i = 0; i < numPlayers; i++)
        {
            maxY = (playersT[i].position.y > maxY) ? playersT[i].position.y : maxY;
            minY = (playersT[i].position.y < minY) ? playersT[i].position.y : minY;
        }
        return ((maxY - minY) / 2);
    }

    void cameraPosition()
    {
        separation = 0;
        for (int i=0; i < numPlayers; i++)
        {
            mid = mid + playersT[i].position;
            if (i>0 && (playersT[i].position - playersT[i-1].position).magnitude > separation)
                separation = (playersT[i].position - playersT[i - 1].position).magnitude;
        }
        mid = mid / numPlayers;
        gameObject.GetComponent<Camera>().orthographicSize = (separation + Ycenter() + sizeOfsset) / 1.8f;


        if (gameObject.GetComponent<Camera>().orthographicSize < minSize)
        {
            gameObject.GetComponent<Camera>().orthographicSize = minSize;
        }

        if (gameObject.GetComponent<Camera>().orthographicSize > maxSize)
        {
            gameObject.GetComponent<Camera>().orthographicSize = maxSize;
        }
    }

}


