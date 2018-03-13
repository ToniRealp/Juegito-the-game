using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour {

    private GameObject playerObject;
    private Collider2D trigger;
    public string playerNumber;
    private float timer = 0f;
    private float timer2;
    private float coolDown = 5f;
    private float duration = 1f;
    private bool isCheck;


    // Use this for initialization
    void Start () {
        playerObject = gameObject;
        trigger = GetComponent<Collider2D>();
        trigger.isTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        timer2 = Time.deltaTime;

        if (timer > coolDown && Input.GetButtonDown(playerNumber + "XboxX"))
        {
            trigger.isTrigger = true;
            timer = 0f;
        }

        if (trigger.isTrigger == true)
        {
            if (isCheck == false)
            {
                isCheck = true;
                timer2 = 0f;
            }

            if (timer2 > duration)
            {
                trigger.isTrigger = false;
                isCheck = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
