using UnityEngine;
using System.Collections.Generic;

public class Teleportation : MonoBehaviour {

//Teleports objects with a target tag that enter Trigger to teleport destination

	public Transform teleportDestination; 
	public string[] targetTags;

	void OnTriggerEnter(Collider other){

		for(int i = 0; i < targetTags.Length; i++){

			if (other.tag == targetTags[i]){

				other.transform.position = teleportDestination.position;
				other.transform.rotation = teleportDestination.rotation;
				break;
			}
		}
	}	
}