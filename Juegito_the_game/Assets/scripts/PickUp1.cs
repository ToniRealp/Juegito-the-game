using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp1 : MonoBehaviour {

    public int effectDuration; 
    public EffectsManager.Effect myEffect;
    public Sprite jump, fly, venom, weight, ultCharge, blast;

    void Start () {
        switch (myEffect)
        {
            case EffectsManager.Effect.Wheight:
                GetComponent<SpriteRenderer>().sprite = weight;
                break;

            case EffectsManager.Effect.Jump:
                gameObject.GetComponent<Transform>().localScale = new Vector3(0.3f, 1f, 0);
                GetComponent<SpriteRenderer>().sprite = jump;
                break;

            case EffectsManager.Effect.Fly:
                GetComponent<SpriteRenderer>().sprite = fly;
                break;

            case EffectsManager.Effect.Venom:
                GetComponent<SpriteRenderer>().sprite = venom;
                break;

            case EffectsManager.Effect.UltCharge:
                GetComponent<SpriteRenderer>().sprite = ultCharge;
                break;

            case EffectsManager.Effect.Blast:
                GetComponent<SpriteRenderer>().sprite = blast;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
            other.GetComponent<EffectsManager>().next = myEffect;
            other.GetComponent<EffectsManager>().time = effectDuration;
            Destroy(gameObject);
        }
    }
}
