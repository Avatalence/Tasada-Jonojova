using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WinScreen : MonoBehaviour {

	public Button MainMenu;
	public Button QuitGame;
	public Button NextLevel;

	// Use this for initialization
	void Start () {

		MainMenu = MainMenu.GetComponent<Button> ();
		QuitGame = QuitGame.GetComponent<Button> ();
		NextLevel = NextLevel.GetComponent<Button> ();
	}
	
	public void StartScreenReturn(){

		Application.LoadLevel (1);
	}

	public void GameTurnOff(){

		Application.Quit ();
	}

	public void NextGame(){

		Application.LoadLevel (2);
	}
}
