using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel("Level01");
	}
	
	public void LoadMenu () {
		Application.LoadLevel("Menu");
	}

	public void LoadInstructions () {
		Application.LoadLevel("Instructions");
	}

	public void LoadCredits () {
		Application.LoadLevel("Credits");
	}

	public void QuitGame () {
		Application.Quit();
	}

}
