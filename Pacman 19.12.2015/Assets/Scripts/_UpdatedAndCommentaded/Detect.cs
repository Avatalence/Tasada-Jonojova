using UnityEngine;
using System.Collections.Generic;

public class Detect : MonoBehaviour {

	//Detects if there's anything that matches a target tag in trigger

	[Tooltip("Checks for all objects with listed tags")]
	public string[] targetTags = {"Untagged"}; //<- Add to and/or change this list in the inspector as needed
	public bool wayClear = true;

	void FixedUpdate(){
		
		wayClear = true;
	}
	public bool WayClear(){

		return(wayClear);
	}
	void OnTriggerStay(Collider other){
		 
		for(int i = 0; i < targetTags.Length; i++){
			if(other.tag == targetTags[i]){
				wayClear = false;
				break;
			}
		}
	}
}
