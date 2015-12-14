using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {
	
	public Button quitGame;
	public Button mainMenu;
	
	void Start () {

		quitGame = quitGame.GetComponent<Button> ();
		mainMenu = mainMenu.GetComponent<Button> ();
	}
	
	public void MainMenu(){

		Application.LoadLevel (1);
	}

	public void ExitGame(){

		Application.Quit ();
	}
}