using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private static float deathDelay = 3f;
	private static float deathDelayCounter = 0f;

	private static int lives = 3;
	private static bool paused = false;
	private static bool won = false;
	private static int currentLives = lives;

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

	public static void WinLevel() {
		won = true;
		Application.LoadLevel("GameOver");
		Screen.showCursor = true; 
	}

	public static int TotalLives() {
		return lives;
	}

	public static int CurrentLives() {
		return currentLives;
	}

	public static void LifeLost() {
		--currentLives;
		deathDelayCounter = Time.time;
	}

	public static void ReloadLevel() {
		deathDelayCounter = 0;
		if (currentLives == 0) {
			currentLives = lives;  // reset number of lives
			Application.LoadLevel("GameOver");
			Screen.showCursor = true; 
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
