 using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StartScreen : MonoBehaviour {

	public Canvas exitMenu;
	public Button startButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {

		exitMenu = exitMenu.GetComponent<Canvas>();
		startButton = startButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button>();
		exitMenu.enabled = false;
	}
	public void ExitButton(){

		exitMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}
	public void NoButtonPress(){

		exitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}
	public void StartGame(){

		Application.LoadLevel (2);
	}
	public void QuitGame(){

		Application.Quit ();
	}
}