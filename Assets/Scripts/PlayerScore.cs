using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public float displayLimit = 2f;

	public Text scoreBoard;
	public GameObject popup;

	private int score;
	private Text guiPopup;
	private RectTransform rect;

	private float counter;

	private void Awake () {
		rect = popup.GetComponent<RectTransform>();
		guiPopup = popup.GetComponent<Text>();
		guiPopup.enabled = false;
	}

	private void Update () {
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y += 0.7f;
		rect.position = newPosition;

		if ((Time.time - counter) > displayLimit) {
			guiPopup.enabled = false;
		}
	}

	public void UpdateScore(int n) {
		score += n;
		scoreBoard.text = PaddingZerosScore();

		guiPopup.text = n.ToString();
		guiPopup.enabled = true;
		counter = Time.time;
	}

	public int FinalScore() {
		return score;
	}

	private string PaddingZerosScore () {
		string numbers = score.ToString();
		string padding = "";
		for (int i = numbers.Length; i < 6; i++) {
			padding += "0";
		}
		return padding + numbers;
	}

}
