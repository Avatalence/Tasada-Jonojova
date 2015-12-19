using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour {

	public static StatsManager instance;
	void Awake(){
		
		if(instance == null){
			
			instance = this as StatsManager;
			
		}else{
			Destroy(gameObject);
		}
		DontDestroyOnLoad (this);
	}	
	public int curLvl;
	public int curWorld;

	public float timePlayed;

	public int playerScore;
	public int playerLives;
	public int toExtralife;

	public int[] highscoreList;

	public void PlayTime(){

		timePlayed += Time.deltaTime;
	}
	public void SaveStats(int _score, int _lives, int _toExtraLife){

		playerScore = _score;
		playerLives = _lives;
		toExtralife = _toExtraLife;
	}
	public void ToHighscore(int _score){

		playerScore = _score;

		for (int i = 0; i < highscoreList.Length; i++) {
			if(_score > highscoreList[i]){
				int _i = highscoreList[i];
				highscoreList[i] = _score;
				_score = _i;
			}
		}
	}
	public void Reset(){
		
		playerScore = 0;
		toExtralife = 0;
		playerLives = 3;
		timePlayed = 0;
		curLvl = 0;	
	}
}
