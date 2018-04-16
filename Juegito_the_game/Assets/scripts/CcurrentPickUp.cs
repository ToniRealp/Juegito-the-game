using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CcurrentPickUp : MonoBehaviour {

    public Sprite jump, fly, venom, weight, ultCharge, blast, none;
    EffectsManager.Effect image;

    void Start () {
        image = GetComponentInParent<EffectsManager>().next;
	}
	
	void Update () {
        image = GetComponentInParent<EffectsManager>().next;
        switch (image) {
            case EffectsManager.Effect.Jump:
                GetComponent<SpriteRenderer>().sprite = jump;
                break;
            case EffectsManager.Effect.Fly:
                gameObject.GetComponent<Transform>().localScale = new Vector3(0.4f,0.4f,0);
                GetComponent<SpriteRenderer>().sprite = fly;
                break;
            case EffectsManager.Effect.Venom:
                GetComponent<SpriteRenderer>().sprite = venom;
                break;
            case EffectsManager.Effect.Wheight:
                GetComponent<SpriteRenderer>().sprite = weight;
                break;
            case EffectsManager.Effect.UltCharge:
                GetComponent<SpriteRenderer>().sprite = ultCharge;
                break;
            case EffectsManager.Effect.Blast:
                GetComponent<SpriteRenderer>().sprite = blast;
                break;
            case EffectsManager.Effect.None:
                gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1  , 0);
                GetComponent<SpriteRenderer>().sprite = none;
                break;
        }
	}
}
