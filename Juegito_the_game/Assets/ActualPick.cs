using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualPick : MonoBehaviour
{

    public Sprite jump, fly, venom, weight, ultCharge, blast, none;
    EffectsManager.Effect image;

    void Start()
    {
        image = GetComponentInParent<EffectsManager>().next;
    }

    void Update()
    {
        image = GetComponentInParent<EffectsManager>().current;
        switch (image)
        {
            case EffectsManager.Effect.Fly:
                GetComponent<SpriteRenderer>().sprite = fly;
                break;
            case EffectsManager.Effect.None:
                GetComponent<SpriteRenderer>().sprite = none;
                break;
        }
    }
}
