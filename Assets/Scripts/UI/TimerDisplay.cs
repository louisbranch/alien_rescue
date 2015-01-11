using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour {

	private int start = 5000;
	private float counter;
	public GameObject gameObj;
	private Text txt;

	private void Start() {
		counter = Time.time;
		txt = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		if ((Time.time - counter) > 1f) {
			start -= 100;
			txt.text = start.ToString();
			counter = Time.time;
		}

	}
}
