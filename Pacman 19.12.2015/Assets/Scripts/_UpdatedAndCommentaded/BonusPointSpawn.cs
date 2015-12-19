using UnityEngine;
using System.Collections.Generic;

public class BonusPointSpawn : MonoBehaviour {

	//Turns On & Off a randomly selected object in an array at set time intervalls.

	public float SpawnTimer;			//The time delay before an object is awoken.  
	public float inGameDuration;		//the time duration the objekt will remain in the scene.
	public float minInGameDuration;		//The minimum value 'inGameDuration' can be adjusted to.
		
	public GameObject[] spawnObjcts;	//The array of objects that will be turned off/on.
	
	StatsManager SM;					//The stats manager to adjust 'inGameDuration' depending on current level. 

	int spawnLocation;					//The randomly generated location where an object will be awoken.
	
	void Start(){

		//Sets 'inGameDuration' depending on current level, deactivates every object in the array and starts the method loop.
		SM = StatsManager.instance;
		inGameDuration = Mathf.Max ((inGameDuration -= SM.curLvl * 2), minInGameDuration);

		for (int i = 0; i < spawnObjcts.Length; i++) {
			spawnObjcts[i].SetActive(false);
		}
		Invoke ("SpawnObject", SpawnTimer);
	}
	void SpawnObject (){

		//Picks a random object in the array and activates it.
		spawnLocation = Random.Range (0,spawnObjcts.Length);

		spawnObjcts [spawnLocation].SetActive (true);
		Invoke("offSet",inGameDuration);
	}
	public void offSet(){

		//Deactivates the randomly selcted object and restarts the method loop.
		spawnObjcts[spawnLocation].SetActive(false);
		Invoke ("SpawnObject", SpawnTimer);
	}
}