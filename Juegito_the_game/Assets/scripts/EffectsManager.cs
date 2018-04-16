using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour {

    public GameObject bombPrefab;
    public enum Effect{ Wheight, Fly, Jump, Venom, UltCharge, Blast, None };
    public int time;
    public Effect next;
    public Effect current;
    bool flyed = false;
    public GameObject me;
    public Transform SpawnPoint;

    void Start () {
		current = Effect.None;
        next = Effect.None;
        SpawnPoint = transform.GetChild(0).GetChild(0).GetChild(0).transform;
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
                GetComponent<Shoot>().ultCharge += 50;
                current = Effect.None;
                break;

            case Effect.Blast:

                GameObject bomb = (GameObject)Instantiate(bombPrefab, SpawnPoint.position, Quaternion.Euler(0, 0, 0));
                bomb.GetComponent<Explode>().owner = me;
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
