using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	//Controlls all ghost behaviour

	ChangeDirection changeDirection;
	GhostStates ghostStates;

	public float speed = 3.5f; // <- Just a recommended base speed. Feel free to change to whatever feels right.
	float curSpeed;
	Vector3 curDirection;
	public Detect front,close,rightSide,leftSide;
	bool justTurned;
	 
	// Use this for initialization
	void Start () {

		changeDirection = GetComponent<ChangeDirection> ();
		ghostStates = GetComponent<GhostStates> ();

		Turn ("Up");
	}
	void FixedUpdate(){

		transform.Translate(curDirection * curSpeed * Time.deltaTime,Space.Self);
	}
	// Update is called once per frame
	void Update () {

		// Checks for decision events 
		if(!justTurned && ghostStates.ghostAwake && (rightSide.WayClear() || leftSide.WayClear())){
			if(!front.WayClear()){
				if (rightSide.WayClear () && leftSide.WayClear ()){
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
		}else if(!rightSide.WayClear() && !leftSide.WayClear()){
			justTurned = false;
		}
	}
	public void Turn(int _turnTo, bool _multiplePaths){

		justTurned = true;

		if (_multiplePaths) {
			curDirection = changeDirection.AIDecision (_turnTo,false);
		} else {
			curDirection = changeDirection.TurnDirection(_turnTo);
		}
	}
	public void Turn(string _directionToTurn){

		curDirection = changeDirection.SetDirection (_directionToTurn);
	}
	public void SetSpeed(float _speedMulitplier){

		curSpeed = speed * _speedMulitplier;
	}
}