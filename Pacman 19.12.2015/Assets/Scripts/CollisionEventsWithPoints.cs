using UnityEngine;
using System.Collections.Generic;

public class CollisionEventsWithPoints : MonoBehaviour {
    
	VictoryCondition VC;
	PacmanStats PMS;

	public GameObject[] ghosts; 

	// Use this for initialization
	void Start () {

		PMS = GetComponent<PacmanStats> ();
		VC = GetComponent<VictoryCondition> ();
	}

	void OnTriggerEnter(Collider other){

		if (VC.CheckForCondition(other.tag) == true) {

			VC.ObjectiveCountdown();
		} 

		if (other.tag == "GenericToken") {

			PMS.ChangeScore (10);
			Destroy (other.gameObject);

		} else if(other.tag == "Ghost"){

			if (other.GetComponent<GhostStates> ().ghostEatable == true) {

				PMS.ChangeScore (200);

			}else if(other.GetComponent<GhostStates>().ghostEatable == false && other.GetComponent<GhostStates>().ghostAlive == true){

				TakeDamage();
			}
				
		} else if (other.tag == "PowerUp") {
            
			for (int i = 0; i < ghosts.Length; i++) {
				ghosts [i].GetComponent<GhostStates> ().ScareGhost ();
			}
			Destroy (other.gameObject);

		} else if (other.tag == "BonusPoint") { 

			PMS.ChangeScore (100);
			other.gameObject.SetActive (false);

		} else if (other.tag == "Key") {

			other.GetComponent<Key> ().UnlockMatchingDoor ();

		} else if (other.tag == "CannonBall") {

			TakeDamage ();

		} else if (other.tag == "Trap") {

			TakeDamage();
		}

		if (VC.objectiveReached == true) {

			StatsManager.instance.curLvl += 1;
			PMS.SaveStates ();
			Application.LoadLevel (4);
		}
	}
	public void TakeDamage(){

		for(int i = 0; i < ghosts.Length; i++){
			ghosts[i].GetComponent<GhostStates>().RestartGhost();
		}
		PMS.ChangeLife (-1);
	}
}