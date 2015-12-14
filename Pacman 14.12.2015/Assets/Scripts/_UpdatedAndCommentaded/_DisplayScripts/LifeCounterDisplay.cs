using UnityEngine;
using System.Collections;

public class LifeCounterDisplay : MonoBehaviour {
   
	//Adjusts the lives displayed when called 

    public GUIText livesText;
   
   	public void LifeChange(int _lifenumber){

		livesText.text = "X " + _lifenumber.ToString ();
	}
}
