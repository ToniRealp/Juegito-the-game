using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public GameObject owner;
    Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(timeToParticles(2.9f));
        StartCoroutine(timeToExplode(3));
        //rb.AddForce(new Vector2(500 * owner.GetComponent<Movement>().side, 500));

    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator timeToParticles(float toWait)
    {
        yield return new WaitForSeconds(toWait);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }

    IEnumerator timeToExplode(float toWait)
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        yield return new WaitForSeconds(toWait);
        CameraMovement camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();

        for (int i = 0; i < camera.players.Length; i++)
        {
            if (camera.players[i] != owner) { 
                Vector3 dist;
                dist = (camera.players[i].GetComponent<Transform>().position - GetComponent<Transform>().position);
                camera.players[i].GetComponent<RespawnDeathCount>().lastHitMe = owner;
                camera.players[i].GetComponent<RespawnDeathCount>().lastHit = true;
                camera.players[i].GetComponent<Rigidbody2D>().AddForce(dist.normalized * 6000);
            }
        }
        Destroy(gameObject);
    }
}
