using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoresDisplay : MonoBehaviour {

	private Text gui;
	
	private void Start() {
		gui = GetComponent<Text>();
	}
	
	private void Update () {
		if (GameControl.Won()) {
			gui.text = "Congratulations!";
		}
	}
}
