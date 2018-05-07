using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public GameObject[] players = new GameObject[4];
    public GameObject[] playerScores = new GameObject[4];
    public GameObject winner;
    public GameObject gameOverParent;
    public Text winnerText;
    bool gameOver;
    public bool paused = true;
    public int numPlayers;
    public bool waitOver = false;
    public GameObject colorPanel;
    public Image colorPanelColor;

    private static int SortByName(GameObject o1, GameObject o2)
    {
        return o1.name.CompareTo(o2.name);
    }

    // Use this for initialization
    void Start (){
        CheckForPlayers();
        SetPlayers();
        gameOver = false;
        gameOverParent.SetActive(false);
        
        StartCoroutine(CountDown(4));

    }
	
	// Update is called once per frame
	void Update (){
        PauseGame();
        gameOver = CheckForPlayers();

        if (gameOver)
            GameOver();
        
        //if one player remains, that player is winner and game over, press A to restart
	}

    void SetPlayers()
    {
       colorPanelColor = colorPanel.GetComponent<Image>();
       numPlayers = StaticValues.playerNumber;

       if(StaticValues.aI == false)
        {
            players[1].GetComponent<AI>().enabled = false;
        } else
        {
            players[1].GetComponent<AI>().enabled = true;
        }

        if(numPlayers == 2)
        {
            players[2].SetActive(false);
            players[3].SetActive(false);
            playerScores[2].SetActive(false);
            playerScores[3].SetActive(false);
            Destroy(players[2]);
            Destroy(players[3]);
            Destroy(playerScores[2]);
            Destroy(playerScores[3]);
        }
        if(numPlayers == 3)
        {
            players[3].SetActive(false);
            playerScores[3].SetActive(false);
            Destroy(players[3]);
            Destroy(playerScores[3]);
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        playerScores = GameObject.FindGameObjectsWithTag("UIP");
    }

    bool CheckForPlayers (){

        players = GameObject.FindGameObjectsWithTag("Player");
        playerScores = GameObject.FindGameObjectsWithTag("UIP");
        Array.Sort(players, SortByName);
        Array.Sort(playerScores, SortByName);

        if (players.Length == 1){

            winner = players[0];
            return true;

        }

        else
            return false;
        
    }

    void GameOver(){

        gameOverParent.SetActive(true);
        winnerText.text = "Winner: " + winner.name;

        if (winner.name == "Player1")
        {
            Color col = colorPanelColor.color;
            col = new Color32(0, 33, 255, 255);
            colorPanelColor.color = col;
        }
        else
        if (winner.name == "Player2")
        {
            Color col = colorPanelColor.color;
            col = new Color32(15, 220, 255, 255);
            colorPanelColor.color = col;
        }
        else
        if (winner.name == "Player3")
        {
            Color col = colorPanelColor.color;
            col = new Color32(0, 228, 34, 255);
            colorPanelColor.color = col;
        }
        else
        if (winner.name == "Player4")
        {
            Color col = colorPanelColor.color;
            col = new Color32(253, 183, 0, 255);
            colorPanelColor.color = col;
        }

        

        if (Input.GetButtonDown("P1_XboxX")|| Input.GetButtonDown("P2_XboxX") || Input.GetButtonDown("P3_XboxX") || Input.GetButtonDown("P4_XboxX"))
            SceneManager.LoadScene("Menu");

    }

   void PauseGame()
    {
        if (paused) {
            foreach (GameObject p in players)
            {
                if (p != null)
                {
                    p.GetComponentInChildren<GunSize>().enabled = false;
                    p.GetComponent<Shoot>().enabled = false;
                    p.GetComponent<Player1Animator>().enabled = false;
                    p.GetComponent<Movement>().enabled = false;
                }
            }
            gameObject.GetComponent<PickUpSpawner>().enabled = false;
        } else
        {

            foreach (GameObject p in players)
            {
                if (p != null)
                {
                    p.GetComponentInChildren<GunSize>().enabled = true;
                    p.GetComponent<Shoot>().enabled = true;
                    p.GetComponent<Player1Animator>().enabled = true;
                    p.GetComponent<Movement>().enabled = true;
                }
            }
            GetComponent<PickUpSpawner>().enabled = true;
        }
    }

    IEnumerator CountDown(float toWait)
    {
        yield return new WaitForSeconds(toWait);
        paused = false;
        waitOver = true;
        foreach (GameObject p in players)
        {
            p.GetComponent<Shoot>().enabled = true;
            p.GetComponent<Player1Animator>().enabled = true;
            p.GetComponent<Movement>().enabled = true;
        }
        GetComponent<PickUpSpawner>().enabled = true;

    }
}
