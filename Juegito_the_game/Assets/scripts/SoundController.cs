using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource chargeFx;
    public AudioSource shootFx;
    public float rtButton;
    public string playerNumber;
    public bool flag;
    public GameObject soundManager;
    public bool isShoot;

	// Use this for initialization
	void Start () {
        chargeFx = soundManager.GetComponents<AudioSource>()[1];
        shootFx = soundManager.GetComponents<AudioSource>()[0];
        flag = true;	
	}
	
	// Update is called once per frame
	void Update () {
        rtButton = Input.GetAxis(playerNumber + "RT");
        //shootFx.volume = GetComponent<Shoot>().shotCharge;

        if (rtButton != 0 && flag){
            chargeFx.Play();
            flag = false;
            isShoot = true;
        }

        if (rtButton == 0 && isShoot) {
            flag = true;
            chargeFx.Stop();
            shootFx.Play();
            isShoot = false;
        }
    }
}
