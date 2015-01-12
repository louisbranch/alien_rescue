using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private static int lives = 3;
	private static bool paused = false;
	private static bool won = false;
	private static int currentLives = lives;

	void Start () {
		Screen.showCursor = false; 
		won = false;
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
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
		if (currentLives == 0) {
			currentLives = lives;  // reset number of lives
			Application.LoadLevel("GameOver");
			Screen.showCursor = true; 
		} else {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
