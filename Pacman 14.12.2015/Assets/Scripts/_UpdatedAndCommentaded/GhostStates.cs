using UnityEngine;
using System.Collections;

public class GhostStates : MonoBehaviour {

	ChangeDirection changeDirection;
	GhostAI ghostAI;

	public Transform playerTarget,insideNestTarget,outsideNestTarget;

	Vector3 startPos;
	public GameObject[] visualizers;

	public bool ghostAwake;
	public float setAwakeTime;
	float awakeTime;

	public bool ghostEatable;
	public float setEatableTime;
	public float minSetEatableTime;
	float eatableTime;

	public bool ghostAlive;

	// Use this for initialization
	void Start () {

		changeDirection = GetComponent<ChangeDirection> ();
		ghostAI = GetComponent<GhostAI>();
		setEatableTime = Mathf.Max ((setEatableTime -= StatsManager.instance.curLvl * 2), minSetEatableTime);

		startPos = transform.position;

		playerTarget =  GameObject.FindGameObjectWithTag("Player").transform;
		insideNestTarget = GameObject.FindGameObjectWithTag("NestTargetInside").transform;
		outsideNestTarget = GameObject.FindGameObjectWithTag("NestTargetOutside").transform;

		awakeTime = setAwakeTime;
	}
	
	// Update is called once per frame
	void Update () {

		if(!ghostAwake){
			if (awakeTime > 0) {
				awakeTime -= Time.deltaTime;
			} else {
				AwakenGhost ();
			}
		}

		if(ghostEatable){
			if( eatableTime > 0){
				eatableTime -= Time.deltaTime;
			}else{
				StartGhost();
			}
		}
	}

	public void AwakenGhost(){

		ghostAwake = true;
		changeDirection.SetNewTarget (outsideNestTarget);
		ghostAI.SetSpeed(0.5f);
	}

	public void StartGhost(){

		ghostEatable = false;
		ghostAlive = true;
		SetVisualizer (0);
		changeDirection.SetNewTarget (playerTarget);
		changeDirection.SetAwayFromTarget (false);
		ghostAI.SetSpeed(1);
	}

	public void ScareGhost(){

		if(ghostAlive){
			if (!ghostEatable) {
				ghostEatable = true;
				SetVisualizer (1);
				changeDirection.SetAwayFromTarget (true);
				ghostAI.Turn(2,false);
			}
			eatableTime = setEatableTime;
		}
	}

	public void KillGhost(){

		ghostAlive = false;
		ghostEatable = false;
		eatableTime = 0;
		SetVisualizer (2); 
		changeDirection.SetAwayFromTarget (false);
		changeDirection.SetNewTarget (outsideNestTarget);
		ghostAI.Turn (2, false);	
		ghostAI.SetSpeed (1.1f);
	}
		
	public void RestartGhost(){

		transform.position = startPos;
		ghostAlive = false;
		ghostAwake = false;
		ghostEatable = false;
		SetVisualizer(0);
		changeDirection.SetAwayFromTarget (false);
		ghostAI.SetSpeed(0);
		ghostAI.Turn ("Up");
		awakeTime = setAwakeTime;
	}

	void OnTriggerEnter(Collider other){

		if(!ghostAlive && ghostAwake && other.tag == "NestTargetInside"){

			AwakenGhost();

		}else if(!ghostEatable && other.tag == "NestTargetOutside"){

			StartGhost();
		}
	}

	void OnCollisionEnter(Collision other){

		if (ghostAlive && other.gameObject.tag == "Ghost") {

			ghostAI.Turn (2, false);	

		}else if(ghostEatable && other.gameObject.tag == "Player"){

			KillGhost();
		}
	}

	public void SetVisualizer(int _visualizer){

		for (int i = 0; i < visualizers.Length; i++) {
			if (_visualizer == i) {
				visualizers [i].SetActive (true);
			} else {
				visualizers [i].SetActive (false);
			}
		}
	}
}
