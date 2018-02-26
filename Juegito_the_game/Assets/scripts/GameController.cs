using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    private GameObject[] players = new GameObject[4];
    private GameObject winner;
    public Canvas canvas;
    public Text winnerText;
    bool gameOver;


    // Use this for initialization
    void Start (){

        gameOver = false;
        canvas.enabled = false;

    }
	
	// Update is called once per frame
	void Update (){

        gameOver = CheckForPlayers();

        if (gameOver)
            GameOver();
        
        //if one player remains, that player is winner and game over, press A to restart
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

        canvas.enabled = true;
        winnerText.text = "Winner: " + winner.name;

        if (Input.GetButtonDown("P1_XboxA")|| Input.GetButtonDown("P2_XboxA"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
