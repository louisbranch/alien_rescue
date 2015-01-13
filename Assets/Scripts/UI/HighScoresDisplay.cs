using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoresDisplay : MonoBehaviour {

	private Text gui;
	
	private void Start() {
		gui = GetComponent<Text>();
		if (GameControl.Won()) {
			gui.text = "Congratulations!";
		}
	}

}
