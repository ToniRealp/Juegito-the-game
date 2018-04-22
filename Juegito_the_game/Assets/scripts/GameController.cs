using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public GameObject[] players = new GameObject[4];
    private GameObject winner;
    public GameObject gameOverParent;
    public Text winnerText;
    bool gameOver;
    public bool paused = true;
    public int numPlayers;
    public bool waitOver = false;


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
       numPlayers = StaticValues.playerNumber;

        if(numPlayers == 2)
        {
            players[1].SetActive(false);
            players[3].SetActive(false);
            Destroy(players[1]);
            Destroy(players[3]);
        }
        if(numPlayers == 3)
        {
            players[3].SetActive(false);
            Destroy(players[3]);
        }

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    bool CheckForPlayers (){

        players = GameObject.FindGameObjectsWithTag("Player");
    
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

        if (Input.GetButtonDown("P1_XboxA")|| Input.GetButtonDown("P2_XboxA"))
            SceneManager.LoadScene("Menu");

    }

   void PauseGame()
    {
        if (paused) { 
            foreach (GameObject p in players)
            {
                if (p != null)
                {
                    p.GetComponent<Shoot>().enabled = false;
                    p.GetComponent<Player1Animator>().enabled = false;
                    p.GetComponent<Movement>().enabled = false;
                    if (waitOver == true) { 
                        p.GetComponent<Rigidbody2D>().isKinematic = true;
                    }
                }
            }
            gameObject.GetComponent<PickUpSpawner>().enabled = false;
        } else
        {
            foreach (GameObject p in players)
            {
                if (p != null)
                {
                    p.GetComponent<Shoot>().enabled = true;
                    p.GetComponent<Player1Animator>().enabled = true;
                    p.GetComponent<Movement>().enabled = true;
                    p.GetComponent<Rigidbody2D>().isKinematic = false;
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
