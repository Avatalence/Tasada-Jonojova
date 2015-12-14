using UnityEngine;
using System.Collections;

public class ScoreTextDisplay: MonoBehaviour {

	//Displays Score text. 
	//Can be alternate between displaying the players current score Or the players highscore by toggling 'highscore' True or False.
	
	public GUIText[] scoreTexts;	//The text strings that will be displayed
	public bool highscore;			//Toggle this in the inspector to switch functionality if you want to displaying the players current score or the players highscore
	
	public StatsManager SM;			//The StatsManager to get the score values from
	
	// Use this for initialization
	void Start () {
		
		SM = StatsManager.instance; 
		
		if (highscore) {
			
			//If 'highscore' is toggled 'True', loops through all text objects in array and writes out highscore value of coresponding order.
			//Breaks the loop if text array is longer than highscore array.
			for (int i = 0; i < scoreTexts.Length; i++) {

				if(i < SM.highscoreList.Length){
					scoreTexts [i].text = "#" + (i+1) + ": " + SM.highscoreList[i].ToString ();
				}else{
					Debug.Log("Tried to write out a highscore value that didn't exist");
					break;
				}
			} 
			
		} else {
			
			//if 'highscore' is toggled 'False', writes out players current score on the first text object in the array. 
			scoreTexts[0].text = "Score: " + SM.playerScore.ToString();
		}
	}
}