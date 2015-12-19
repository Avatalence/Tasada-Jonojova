using UnityEngine;
using System.Collections;

public class BarrelRespawn : MonoBehaviour {
	public GameObject Barrel;
	public float RepeatRate = 5.0f;
	void Start () {
		InvokeRepeating ("BarrelRespawns", 0.0f, RepeatRate);
	}
	
	// Update is called once per frame
	void BarrelRespawns () {
		Instantiate (Barrel, transform.position, transform.rotation);
	}
}
