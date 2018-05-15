using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

	public ParticleSystem shootExplosion;
	void Start () {

        shootExplosion = GetComponentInChildren<ParticleSystem>();

	}
	
	
	void Update () {
		
       

	}
}
