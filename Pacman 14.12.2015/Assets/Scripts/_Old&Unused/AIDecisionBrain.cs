using UnityEngine;
using System.Collections;

public class AIDecisionBrain : MonoBehaviour {

	public Transform targetAssistLeft, targetAssistRight, targetAssistFront;

	bool awayFromTarget;
	Transform curTarget;

	void Start(){

	}

	public int AIDecision(int _pathOptionsState){

		int _toTurn = 0;

		if(_pathOptionsState == 0 && !awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistRight.position)
				< Vector3.Distance(curTarget.position,targetAssistLeft.position)){

				_toTurn = 1;

			}else{

				_toTurn = 3;
			}

		}else if(_pathOptionsState == 0 && awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistRight.position)
				> Vector3.Distance(curTarget.position,targetAssistLeft.position)){

				_toTurn = 1;

			}else{

				_toTurn = 3;
			}

		}else if(_pathOptionsState == 1 && !awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
				< Vector3.Distance(curTarget.position,targetAssistRight.position)){

				_toTurn = 0;

			}else{

				_toTurn = 1;
			}

		}else if(_pathOptionsState == 1 && awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
				> Vector3.Distance(curTarget.position,targetAssistRight.position)){

				_toTurn = 0;

			}else{

				_toTurn = 1;
			}

		}else if(_pathOptionsState == 2 && !awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
				< Vector3.Distance(curTarget.position,targetAssistLeft.position)){

				_toTurn = 0;

			}else{

				_toTurn = 3;
			}

		}else if(_pathOptionsState == 2 && awayFromTarget){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
				> Vector3.Distance(curTarget.position,targetAssistLeft.position)){

				_toTurn = 0;

			}else{

				_toTurn = 3;
			}

		}else if(_pathOptionsState == 3 && !awayFromTarget){

			if(Mathf.Min(Vector3.Distance(curTarget.position,targetAssistRight.position),
				Vector3.Distance(curTarget.position,targetAssistLeft.position)) 
				> Vector3.Distance(curTarget.position,targetAssistFront.position)){

				_toTurn = 0;

			}else{

				if(Vector3.Distance(curTarget.position,targetAssistRight.position) 
					< Vector3.Distance(curTarget.position,targetAssistLeft.position)){

					_toTurn = 1;

				}else{

					_toTurn = 3;
				}
			}

		}else if(_pathOptionsState == 3 && awayFromTarget){

			if(Mathf.Min(Vector3.Distance(curTarget.position,targetAssistRight.position),
				Vector3.Distance(curTarget.position,targetAssistLeft.position)) 
				> Vector3.Distance(curTarget.position,targetAssistFront.position)){

				_toTurn = 0;

			}else{

				if(Vector3.Distance(curTarget.position,targetAssistRight.position) 
					> Vector3.Distance(curTarget.position,targetAssistLeft.position)){

					_toTurn = 1;

				}else{

					_toTurn = 3;
				}
			}
		}
		return _toTurn;
	}

	public void SetNewTarget(Transform _target){

		curTarget = _target;
	}

	public void SetFlee(bool _b){

		awayFromTarget = _b;
	}
}
