using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkText : MonoBehaviour {

	public float seconds = 2f;

	public string[] dialogs;

	private Text gui;

	private void Awake () {
		gui = GetComponent<Text>();
	}

	private void Start () {
		InvokeRepeating("ToggleText", seconds, seconds);
	}

	private void ToggleText () {
		int i = Random.Range(0, dialogs.Length);
		string dialog = dialogs[i];
		gui.text = dialog;
		gui.enabled = !gui.enabled;
	}
}
