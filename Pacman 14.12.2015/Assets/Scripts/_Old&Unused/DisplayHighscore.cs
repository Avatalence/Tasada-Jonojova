using UnityEngine;
using System.Collections;

public class DisplayHighscore : MonoBehaviour {

	//Displays Score text. 
	//Can be alternate between displaying the players current score Or the players highscore by toggling 'highscore' True or False.

	public GUIText[] scoreTexts;	//The text strings that will be displayed
	public bool highscore;			//Toggle this to switch functionality if you want to displaying the players current score or the players highscore

	public StatsManager SM;			//The StatsManager to get the score values from

	// Use this for initialization
	void Start () {

		SM = StatsManager.instance;

		if (highscore) {

			//If 'highscore' is toggled 'True', loops through all text objects in array and writes out highscore value of coresponding order. 
			for (int i = 0; i < scoreTexts.Length; i++) {

				scoreTexts [i].text = "#" + i + ": " + SM.highscoreList[i].ToString ();
			} 
		
		} else {

			//if 'highscore' is toggled 'False', writes out players current score on the first text object in the array. 
			scoreTexts[0].text = "Score: " + SM.playerScore.ToString();
		}
	}
}
