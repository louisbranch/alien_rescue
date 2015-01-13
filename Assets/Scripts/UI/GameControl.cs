using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private static float deathDelay = 3f;
	private static float deathDelayCounter = 0f;

	private static int lives = 3;
	private static bool paused = false;
	private static bool won = false;
	private static int currentLives = lives;
	private static int highscore = 0;

	void Start () {
		Screen.showCursor = false; 
		won = false;
	}
	
	void Update () {

		if (deathDelayCounter > 0 && (Time.time - deathDelayCounter) > deathDelay) {
			ReloadLevel();
		}
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
			Screen.showCursor = true;
		}

		if (Input.GetButtonDown("Pause")) {
			if (paused) {
				Time.timeScale = 0f;
			} else {
				Time.timeScale = 1f;
			}
			paused = !paused;
		}

	}

	public static bool Won() {
		return won;
	}

	public static int Highscore() {
		return highscore;
	}

	public static void WinLevel(int score) {
		won = true;
		SaveHighscore(score);
		ResetDefaults();
	}

	public static int TotalLives() {
		return lives;
	}

	public static int CurrentLives() {
		return currentLives;
	}

	public static void LifeLost(int score) {
		--currentLives;
		deathDelayCounter = Time.time;
		SaveHighscore(score);
	}

	public static void ReloadLevel() {
		deathDelayCounter = 0;
		if (currentLives == 0) {
			ResetDefaults();
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	private static void SaveHighscore(int score) {
		if (score > highscore) {
			highscore = score;
		}
		//TODO save into player preferences
	}

	private static void ResetDefaults() {
		currentLives = lives;
		highscore = 0;
		Application.LoadLevel("GameOver");
		Screen.showCursor = true;
	}

}