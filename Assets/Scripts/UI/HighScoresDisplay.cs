using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighscoresDisplay : MonoBehaviour {

	public Text title;
	public Text scores;
	
	private void Awake() {
		scores.text = "";
		if (GameControl.Won()) {
			title.text = "Congratulations!";
		}
		for (int i = 0; i < 5; i++) {
			int score = PlayerPrefs.GetInt("highscore_" + i);
			scores.text += i+1 + ". " + PaddingZerosScore(score) + "\n";
		}
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
