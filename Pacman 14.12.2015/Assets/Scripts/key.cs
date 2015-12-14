using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public Door matchingDoor;
			
	public void UnlockMatchingDoor(){

		matchingDoor.unlock ();
	}
}
