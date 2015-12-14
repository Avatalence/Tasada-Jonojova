using UnityEngine;
using System.Collections;

public class StatsReset : MonoBehaviour {

	//Resets player stats to a defined default
	//Put this on an empty object in a scene where you want to have the players stats reset

	// Use this for initialization
	void Start () {

		StatsManager.instance.Reset ();
	}
}
