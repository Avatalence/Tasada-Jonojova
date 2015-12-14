using UnityEngine;
using System.Collections;

public class ChangeDirection : MonoBehaviour {
	
//Handles the change of direction of an object that have it's movement restricted to four directions and it's visual rotation in a seperate object.

	public GameObject orientator;		//The object to rotate. 

	int orientation = 0;				//The objects orientation depicted by an int value. 0 = Up, 1 = Right, 2 = Down and 3 = left.
	Vector3 newDirection;				//The new direction to be returned.

	public Transform[] targetAssists;	//Surrounding positions used to decide which direction to turn towards by comparing distances to target
										// ^ Must be put in the order Left ([0]), Up ([1]) and Right ([2]) to work.
	public Transform target;					//The target used in determining which direction to turn.
	bool awayFromTarget;				//Determines if AI should decide to turn away from or towards target.  	

	//Sets direction to a decided orientation unregarding the current orientation
	public Vector3 SetDirection(string _direction){
		if(_direction == "Up"){
			orientator.transform.rotation = Quaternion.Euler(0,0,0);
			newDirection = Vector3.forward;
			orientation = 0;
		}else if(_direction == "Right"){
			orientator.transform.rotation = Quaternion.Euler(0,90,0);
			newDirection = Vector3.right;
			orientation = 1;
		}else if(_direction == "Down"){
			orientator.transform.rotation = Quaternion.Euler(0,180,0);
			newDirection = Vector3.back;
			orientation = 2;
		}else if(_direction == "Left"){
			orientator.transform.rotation = Quaternion.Euler(0,270,0);
			newDirection = Vector3.left;
			orientation = 3;
		}
		return newDirection;
	}
	//Changes direction to a new origentation bases on the current orientation
	public Vector3 TurnDirection(int _turnDirection){

		_turnDirection += orientation;

		//lowers the incoming turn direction to less than four to match orientation length
		while(_turnDirection >= 4) {
			_turnDirection -= 4;
		}
		if (_turnDirection == 0) {
			orientator.transform.rotation = Quaternion.Euler (0, 0, 0);
			newDirection = Vector3.forward;
			orientation = 0;
		} else if (_turnDirection == 1) {
			orientator.transform.rotation = Quaternion.Euler (0, 90, 0);
			newDirection = Vector3.right;
			orientation = 1;
		} else if (_turnDirection == 2) {
			orientator.transform.rotation = Quaternion.Euler (0, 180, 0);
			newDirection = Vector3.back;
			orientation = 2;
		} else if (_turnDirection == 3) {
			orientator.transform.rotation = Quaternion.Euler(0,270,0);
			newDirection = Vector3.left;
			orientation = 3;
		}
		return newDirection;
	}
	//Decides a dirction to turn towards out of multiple path options
	// '_unavailablePathOption' is the path option that is unavailable and will be ignored in the calculation
	// ^ [0] = ignore left, [1] = ignore up, and [2] = ignore right. [3+] if all path options are available. 
	// '_random' decides if the  diection to turn towards is generated randomly or calculated bases on a targets position
	public Vector3 AIDecision(int _unavailablePathOption, bool _random){

		int _toTurn = 0; //The direction to turn towards

		if (_random) {
			int _randomResult = Random.Range (0, 3); //The randomly generated direction to turn towards

			//Loops the randomizer until random result is set to an available path option
			while (_randomResult == _unavailablePathOption) {
				_randomResult = Random.Range (0, 3);
			}
			_toTurn = _randomResult + 3; //<- This is why target assists must be put in the order Left, Up, Right to work. 
										// ^ 0+3 = Left, 1+3 = Up & 2+3 = Right after having been readjusted to match orientation length in 'TurnDirection'
		} else {
			float _distance = 0; //The saved distance value to compare with

			//Loops through all target assists in array
			for (int i = 0; i < targetAssists.Length; i++) {
				//Ignores unavailable path options
				if (i != _unavailablePathOption) {
					//Sets values without any comparisons if '_distance' is not yet set. 
					if (_distance == 0) {
						_distance = Vector3.Distance (target.position, targetAssists [i].position);
						_toTurn = i + 3;	
					} else {
						//saves values of the longest or shortest distance depending on if set to turn towards or away from target
						if (awayFromTarget) {
							if (Vector3.Distance (target.position, targetAssists [i].position) > _distance) {
								_distance = Vector3.Distance (target.position, targetAssists [i].position);
								_toTurn = i + 3;
							}
						} else {
							if (Vector3.Distance (target.position, targetAssists [i].position) < _distance) {
								_distance = Vector3.Distance (target.position, targetAssists [i].position);
								_toTurn = i + 3;
							}
						}
					}
				}
			}
		}
		return TurnDirection (_toTurn);
	}
	public void SetNewTarget(Transform _target){

		target = _target;
	}
	public void SetAwayFromTarget(bool _b){

		awayFromTarget = _b;
	}
}