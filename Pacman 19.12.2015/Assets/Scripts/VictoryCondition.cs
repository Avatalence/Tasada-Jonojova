using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {

	public GameObject[] objectives;
	public int countdown;
	public bool objectiveReached = false;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < objectives.Length; i++) {

			countdown += GameObject.FindGameObjectsWithTag (objectives [i].tag).Length;
		}
	}
	public void ObjectiveCountdown(){
		
		countdown--;
		if (countdown <= 0) {
			objectiveReached = true;
		}
	}

	public bool CheckForCondition(string _target){

		bool targetFound = false;

		for (int i = 0; i < objectives.Length; i++) {
			if (objectives [i].tag == _target) {
				targetFound = true;
				break;
			}
		}
		return targetFound;
	}
}
