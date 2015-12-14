using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	//Controlls all ghost behaviour

	ChangeDirection changeDirection;
	GhostStates ghostStates;

	public float speed = 3.5f; // <- Just a recommended base speed. Feel free to change to whatever feels right. (Recomended speed 1.5 <-> 5.5)

	float curSpeed;
	Vector3 curDirection;

	public Detect front,close,rightSide,leftSide;

	bool justTurned;
	float turnCooldown;
	float setTurnCooldown;
	 
	// Use this for initialization
	void Start () {

		changeDirection = GetComponent<ChangeDirection> ();
		ghostStates = GetComponent<GhostStates> ();

		setTurnCooldown = 0.5f / (speed + 0.1f);

		Turn("Up");
	}
	
	// Update is called once per frame
	void Update () {

		//Eliminates random, physics based motion
		GetComponent<Rigidbody>().velocity = Vector3.zero;

		transform.Translate(curDirection * curSpeed * Time.deltaTime,Space.Self);

		// Checks for decision events 
		if(!justTurned && ghostStates.ghostAwake && (rightSide.WayClear() || leftSide.WayClear())){

			curSpeed = 0;

			if(!front.WayClear()){
				
				if(rightSide.WayClear() && leftSide.WayClear()){

					Turn(1, true);
					
				}else if(rightSide.WayClear()){
					
					Turn(1, false);
					
				}else if(leftSide.WayClear()){
					
					Turn(3, false);
				}
				
			}else if(front.WayClear()){
				
				if(rightSide.WayClear() && leftSide.WayClear()){
					
					Turn(3, true);
					
				}else if(rightSide.WayClear()){
					
					Turn(0, true);
					
				}else if(leftSide.WayClear()){
					
					Turn(2, true);
				}
			}

		}else if(!close.WayClear() && !justTurned && ghostStates.ghostAwake){
			
			Turn(2,false);	
		}

		if(turnCooldown > 0){
			turnCooldown -= Time.deltaTime;
		}else{
			justTurned = false;
		}
	}

	public void Turn(int _turnTo, bool _multiplePaths){

		justTurned = true;
		turnCooldown = setTurnCooldown;

		if (_multiplePaths) {
			curDirection = changeDirection.AIDecision (_turnTo,false);
		} else {
			curDirection = changeDirection.TurnDirection(_turnTo);
		}
		curSpeed = speed;
	}

	public void Turn(string _directionToTurn){

		curDirection = changeDirection.SetDirection (_directionToTurn);
	}

	public void SetSpeed(float _speedMulitplier){

		curSpeed = speed * _speedMulitplier;
	}

	public bool GetJustTurned(){

		return justTurned;
	}
}