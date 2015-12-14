using UnityEngine;
using System.Collections;

public class RotationDiamonds : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(Time.deltaTime, 1, 0);
	}
}
