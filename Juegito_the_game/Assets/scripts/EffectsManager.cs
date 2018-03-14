using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour {

    public enum Effect{ Wheight, Fly, Jump, Venom, UltCharge, Blast, None };
    public int time;
    public Effect current;
    bool flyed = false;
    public GameObject me;

	void Start () {
		current = Effect.None;
    }
	
	// Update is called once per frame
	void Update () {
		switch (current)
        {
            case Effect.Wheight:
                GetComponent<Rigidbody2D>().mass = 2;
                StartCoroutine(WaitAndNormal(time));
                break;

            case Effect.Jump:
                GetComponent<Movement>().jumpForce = 3800;
                StartCoroutine(WaitAndNormal(time));
                break;

            case Effect.Fly:
                GetComponent<Movement>().onFloor = true;
                StartCoroutine(WaitAndNormal(time));
                flyed = true;
                break;

            case Effect.Venom:
                GetComponent<Shoot>().venom = true;
                StartCoroutine(WaitAndNormal(time));
                break;

            case Effect.UltCharge:
                GetComponent<Shoot>().ultCharge = 100;
                current = Effect.None;
                break;

            case Effect.Blast:
                CameraMovement camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();

                for (int i = 0; i < camera.players.Length; i++){
                    Vector3 dist;
                    dist =(camera.players[i].GetComponent<Transform>().position - GetComponent<Transform>().position);
                    camera.players[i].GetComponent<RespawnDeathCount>().lastHitMe = me;
                    camera.players[i].GetComponent<RespawnDeathCount>().lastHit = true;
                    camera.players[i].GetComponent<Rigidbody2D>().AddForce(dist.normalized * 3000);
                }

                current = Effect.None;
                break;

            case Effect.None:
                if (flyed) { 
                    GetComponent<Movement>().onFloor = false;
                    flyed = false;
                }

                GetComponent<Rigidbody2D>().mass = 1;
                GetComponent<Movement>().jumpForce = 1800;
                break;
        }
	}

    IEnumerator WaitAndNormal(float toWait)
    {
        yield return new WaitForSeconds(toWait);
        current = Effect.None;
    }
}
