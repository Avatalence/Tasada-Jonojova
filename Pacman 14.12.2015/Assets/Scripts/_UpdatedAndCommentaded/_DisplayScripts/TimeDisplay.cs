using UnityEngine;
using System.Collections;

public class TimeDisplay : MonoBehaviour {

	//Updates the displayed time Played with one decimal 

	public GUIText gameTime;
	
	// Update is called once per frame
	void Update () {

		gameTime.text = StatsManager.instance.timePlayed.ToString ("F1");
	}
}