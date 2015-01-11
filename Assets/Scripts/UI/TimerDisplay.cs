using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour {

	private int start = 5000;
	private float counter;
	private Text gui;

	private void Start() {
		counter = Time.time;
		gui = GetComponent<Text>();
	}
	
	private void Update () {
		if ((Time.time - counter) > 1f) {
			start -= 100;
			gui.text = start.ToString();
			counter = Time.time;
		}

	}
}
