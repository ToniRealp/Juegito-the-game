using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{

    public GameObject PickUpPrefab;
    private float Timer = 0;
    public int minT, maxT;

    // Use this for initialization
    void Start()
    {
        
    }
    void Update()
    {
        if (Timer < Time.time)
        {
            GameObject pickup = (GameObject)Instantiate(PickUpPrefab, new Vector3(Random.Range(-9f, 21f), 9f, 0), Quaternion.identity);
            pickup.GetComponent<PickUp1>().myEffect = (EffectsManager.Effect) Random.Range(0, 6);
            Timer = Time.time + Random.Range(minT, maxT);
        }
    }
}

	


