using UnityEngine;
using System.Collections;

public class PacmanStats : MonoBehaviour {

	StatsManager SM;

	Vector3 startPos;

	int score;
	public GUIText scoreDisplay;
	int curToExtraLife;
	public int neededForExtraLife;
	int pacmanLives;
	public GUIText livesDisplay;

	// Use this for initialization
	void Start () {

		SM = StatsManager.instance;
		score = SM.playerScore;
		pacmanLives = SM.playerLives;
		curToExtraLife = SM.toExtralife;

		scoreDisplay.text = score.ToString ();
		livesDisplay.text = "X " + pacmanLives.ToString ();
	
		startPos = transform.position;
	}
	public void ChangeScore(int _score){

		score += _score;
		scoreDisplay.text = score.ToString ();

		curToExtraLife += _score;
		if (curToExtraLife >= neededForExtraLife) {
			ChangeLife (1);
			curToExtraLife = 0;
		}
	}
	public void ChangeLife(int _value){

		pacmanLives += _value;
		if (_value > 0) {
			pacmanLives = Mathf.Min (pacmanLives, 6);
		} else {
			if(pacmanLives <= 0){

				SM.ToHighscore(score);

				Application.LoadLevel(3);
			}
			transform.position = startPos;
		}
		livesDisplay.text = "X " + pacmanLives.ToString ();
	}
	public void SaveStates(){

		SM.SaveStats (score, pacmanLives, curToExtraLife); 
	}
}
