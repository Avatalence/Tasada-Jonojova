using UnityEngine;
using System.Collections;

public class OverworldManager : MonoBehaviour {

	public static OverworldManager instance;
	void Awake(){

		if (instance == null) {

			instance = this as OverworldManager;

		} else {
			Destroy (gameObject);
		}
	}	
				
	public GameObject playerAvatar;
	OverworldNode curWorld;
	float speed = 2;
	bool traveling;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			NavigateToWorld (curWorld.worldOptions[0]);
		}else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			NavigateToWorld (curWorld.worldOptions[1]);
		}else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			NavigateToWorld (curWorld.worldOptions[2]);
		}else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			NavigateToWorld (curWorld.worldOptions[3]);
		}
	
		playerAvatar.transform.Translate (transform.forward * speed * Time.deltaTime);
	}

	public void NavigateToWorld(OverworldNode _world){

		if (_world != null) {

			if(_world.unlocked && !traveling){

				playerAvatar.transform.LookAt (_world.transform.position);
				speed = 6;
				traveling = true;
			}
		}
	}

	public void NewWorld(OverworldNode _newWorld){
		
		curWorld = _newWorld;
		speed = 0;
		playerAvatar.transform.rotation = Quaternion.Euler(0,90,0);
		traveling = false;

	}
}
