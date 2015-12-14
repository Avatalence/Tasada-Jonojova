using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public int locks;

	public void unlock(){

		locks--;
		if (locks <= 0) {
			gameObject.SetActive (false);
		}
	}
}
