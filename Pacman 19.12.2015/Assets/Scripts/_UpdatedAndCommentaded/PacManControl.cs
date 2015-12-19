using UnityEngine;
using System.Collections.Generic;

public class PacManControl : MonoBehaviour {

	ChangeDirection changeDirection;
	public float speed = 2; // <- Just a recommended base speed. Feel free to change to whatever feels right.
	float curSpeed;
	public KeyCode up = KeyCode.UpArrow, down = KeyCode.DownArrow, right = KeyCode.RightArrow, left = KeyCode.LeftArrow;
	Vector3 curDirection;
	public Detect upSide, downSide, rightSide, leftSide, front;		
	bool XZ, posNeg;
	// ^ is basically a 2bit system to determine between 4 different states (up, down, right, left) ...
	//is set by if the direction is along the X (true) or Z (false) axis and if the direction is positive (true) or negative (false).

	void Start(){
		changeDirection = GetComponent<ChangeDirection> ();
	}
	void FixedUpdate(){
		
		transform.Translate(curDirection * curSpeed * Time.deltaTime ,Space.Self);
	}
	// Update is called once per frame
	void Update () {

		StatsManager.instance.PlayTime ();

		//Changes direction to the direction of last pressed directional key if the way in that direction is clear
		if(Input.GetKey(up) && (!XZ && posNeg) && upSide.WayClear()){
			Turn("Up");
		}else if(Input.GetKey(down) && (!XZ && !posNeg) && downSide.WayClear()){
			Turn("Down");
		}else if(Input.GetKey(right) && (XZ && posNeg) && rightSide.WayClear()){
			Turn("Right");
		}else if(Input.GetKey(left) && (XZ && !posNeg) && leftSide.WayClear()){
			Turn("Left");
		}
		//Sets direction of last pressed directional key...
		//This setup is to enable the continious responsivness of 'GetKey' while only reacting to the last pressed directional key
		if(Input.GetKeyDown(up)){
			XZ = false; posNeg = true;
		}else if(Input.GetKeyDown(down)){
			XZ = false; posNeg = false;
		}else if(Input.GetKeyDown(right)){
			XZ = true; posNeg = true;
		}else if(Input.GetKeyDown(left)){
			XZ = true; posNeg = false;
		}
		//sets current speed to 0 if colliding with a wall in the current direction of movement...
		//Pretty much a self-made 'OnCollisionEnter' with the benefit of working better in tight paths.
		if (!front.WayClear ()) {
			curSpeed = 0;
		}
	}
	//Sets new vizualiser orientation and movement direction to defined settings
	void Turn(string _direction){

		curDirection = changeDirection.SetDirection (_direction);
		curSpeed = speed;
	}
}