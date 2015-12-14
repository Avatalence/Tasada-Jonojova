using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollisionEventsWithPoints : MonoBehaviour {
    
	Vector3 startPos;
	public int scorenumber = 0;
	public int toExtraLife;
	public Text scoretext;
	public int toVictory = 0;

	public int pacmanlives;
	public LifeCounterDisplay lifeDisplay;

	public GameObject[] ghosts; 

	public StatsManager SM;
	
	// Use this for initialization
	void Start () {

		SM = StatsManager.instance;

		startPos = transform.position;
		pacmanlives = SM.playerLives;
		lifeDisplay.LifeChange(pacmanlives);
		scorenumber = SM.playerScore;
		toExtraLife = SM.toExtralife;
		scoretext.text = scorenumber.ToString();
	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Ghost" && other.gameObject.GetComponent<GhostStates>().ghostEatable == true){

			scorenumber = scorenumber + 200;
			toExtraLife += 200;
			scoretext.text = scorenumber.ToString();

		}else if(other.gameObject.tag == "Ghost" && other.gameObject.GetComponent<GhostStates>().ghostEatable == false 
													&& other.gameObject.GetComponent<GhostStates>().ghostAlive == true){
			TakeDamage();
 		}
	}

	void OnTriggerEnter(Collider other){

		if (toExtraLife >= 3500) {
			
			pacmanlives++;
			if(pacmanlives > 6){
				pacmanlives = 6;
			}
			toExtraLife = 0;
			lifeDisplay.LifeChange(pacmanlives);
		}
	
		if (other.tag == "GenericToken") {
        
			scorenumber += 10;
			toExtraLife += 10;
			Destroy (other.gameObject);
			scoretext.text = scorenumber.ToString ();
			toVictory++;
        
		} else if (other.tag == "PowerUp") {
            
			for (int i = 0; i < ghosts.Length; i++) {
				ghosts [i].GetComponent<GhostStates> ().ScareGhost ();
			}
			Destroy (other.gameObject);
			toVictory++;

		} else if (other.tag == "BonusPoint") { 

			scorenumber += 100;
			toExtraLife += 100;
			other.gameObject.SetActive(false);
			scoretext.text = scorenumber.ToString ();

		} else if (other.tag == "CannonBall") {

			TakeDamage();

		}if (other.gameObject.tag =="Trap"){

			TakeDamage();
		
		}else if(other.tag == "Key"){

			other.GetComponent<Key> ().UnlockMatchingDoor ();
		}

		if (toVictory >= 291) {

			SM.curLvl += 1;
			SM.playerLives = pacmanlives;
			SM.setScore(scorenumber);
			SM.toExtralife = toExtraLife;
			Application.LoadLevel (4);
		}
	}

	void TakeDamage(){

		for(int i = 0; i < ghosts.Length; i++){
			ghosts[i].GetComponent<GhostStates>().RestartGhost();
		}
		transform.position = startPos;
		pacmanlives--;
		lifeDisplay.LifeChange(pacmanlives);
		if(pacmanlives<=0){
			
			SM.setScore(scorenumber);
			SM.ToHighscore(scorenumber);
			Application.LoadLevel(3);
		}
	}
}