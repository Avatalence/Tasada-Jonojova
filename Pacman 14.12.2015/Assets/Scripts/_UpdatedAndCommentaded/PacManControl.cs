using UnityEngine;
using System.Collections.Generic;

public class PacManControl : MonoBehaviour {

	[Tooltip("visual model object here")]
	public GameObject vizualiser;
	public float speed = 2; // <- Just a recommended base speed. Feel free to change to whatever feels right.
	float curSpeed;
	public KeyCode up = KeyCode.UpArrow, down = KeyCode.DownArrow, right = KeyCode.RightArrow, left = KeyCode.LeftArrow;
	Vector3 curDirection;
	public Detect upSide, downSide, rightSide, leftSide;		
	bool XZ, posNeg;
	// ^ is basically a 2bit system to determine between 4 different states (up, down, right, left) ...
	//is set by if the direction is along the X (true) or Z (false) axis and if the direction is positive (true) or negative (false).

	// Update is called once per frame
	void Update () {

		StatsManager.instance.PlayTime ();

		//Eliminates random, physics based motion
		GetComponent<Rigidbody>().velocity = Vector3.zero;

		//Changes direction to the direction of last pressed directional key if the way in that direction is clear
		if(Input.GetKey(up) && !XZ && posNeg && upSide.WayClear()){
			ChangeDirection("Up");
		}else if(Input.GetKey(down) && !XZ && !posNeg && downSide.WayClear()){
			ChangeDirection("Down");
		}else if(Input.GetKey(right) && XZ && posNeg && rightSide.WayClear()){
			ChangeDirection("Right");
		}else if(Input.GetKey(left) && XZ && !posNeg && leftSide.WayClear()){
			ChangeDirection("Left");
		}
		//Sets direction of last pressed directional key...
		//This setup is to enable the continious responsivness of 'GetKey' while only reacting to the last pressed directional key 
		//(This mimics the original PacMan behaviour)
		if(Input.GetKeyDown(up)){
			XZ = false; posNeg = true;
		}else if(Input.GetKeyDown(down)){
			XZ = false; posNeg = false;
		}else if(Input.GetKeyDown(right)){
			XZ = true; posNeg = true;
		}else if(Input.GetKeyDown(left)){
			XZ = true; posNeg = false;
		}
		transform.Translate(curDirection * curSpeed * Time.deltaTime,Space.Self);

		//sets current speed to 0 if colliding with a wall in the current direction of movement...
		//Pretty much a self-made 'OnCollisionEnter' with the benefit of working better in tight paths.
		if(curDirection == Vector3.forward && !upSide.WayClear()){
			curSpeed = 0;
		}else if(curDirection == Vector3.back && !downSide.WayClear()){
			curSpeed = 0;
		}else if(curDirection == Vector3.right && !rightSide.WayClear()){
			curSpeed = 0;
		}else if(curDirection == Vector3.left && !leftSide.WayClear()){
			curSpeed = 0;
		}
	}
	//Sets new vizualiser orientation and movement direction to defined settings
	void ChangeDirection(string _direction){
		if(_direction == "Up"){
			vizualiser.transform.rotation = Quaternion.Euler(0,0,0);
			curDirection = Vector3.forward;
		}else if(_direction == "Down"){
			vizualiser.transform.rotation = Quaternion.Euler(0,180,0);
			curDirection = Vector3.back;
		}else if(_direction == "Right"){
			vizualiser.transform.rotation = Quaternion.Euler(0,90,0);
			curDirection = Vector3.right;
		}else if(_direction == "Left"){
			vizualiser.transform.rotation = Quaternion.Euler(0,270,0);
			curDirection = Vector3.left;
		}
		curSpeed = speed;
	}
}