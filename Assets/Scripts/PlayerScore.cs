using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public int bonusTime = 5000;
	public float displayLimit = 2f;
	public GameObject popup;
	public Text guiScore;
	public Text guiTimer;
	public Text guiHighscore;

	private int score;
	private int highscore;
	private Text guiPopup;
	private RectTransform rect;
	private float bonusCounter;
	private float displayCounter;

	private void Awake () {
		rect = popup.GetComponent<RectTransform>();
		guiPopup = popup.GetComponent<Text>();
		guiPopup.enabled = false;
		highscore = GameControl.Highscore();
	}
	
	private void Start() {
		bonusCounter = Time.time;
		guiHighscore.text = PaddingZerosScore(highscore);
	}

	private void Update () {
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y += 0.7f;
		rect.position = newPosition;

		float time = Time.time;

		if ((time - displayCounter) > displayLimit) {
			guiPopup.enabled = false;
		}

		if ((time - bonusCounter) > 1f) {
			bonusTime -= 100;
			guiTimer.text = bonusTime.ToString();
			bonusCounter = time;
		}
	}

	public void UpdateScore(int n) {
		score += n;
		if (score > highscore) {
			highscore = score;
			guiHighscore.text = PaddingZerosScore(score);
		}
		guiScore.text = PaddingZerosScore(score);

		guiPopup.text = n.ToString();
		guiPopup.enabled = true;
		displayCounter = Time.time;
	}

	public int WinningScore() {
		return score + bonusTime;
	}
	
	public int LosingScore() {
		return score;
	}

	private string PaddingZerosScore (int score) {
		string numbers = score.ToString();
		string padding = "";
		for (int i = numbers.Length; i < 6; i++) {
			padding += "0";
		}
		return padding + numbers;
	}

}
