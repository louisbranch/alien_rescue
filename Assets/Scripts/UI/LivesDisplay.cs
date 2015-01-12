using UnityEngine;
using System.Collections;

public class LivesDisplay : MonoBehaviour {

	public GameObject lifeFull;
	public GameObject lifeEmpty;
	
	void Start () {
		int lives = GameControl.CurrentLives();
		int max = GameControl.TotalLives();
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
		for (int i = 0; i < max; i++) {
			if (lives > 0) {
				Instantiate(lifeFull, position, Quaternion.identity);
				--lives;
			} else {
				Instantiate(lifeEmpty, position, Quaternion.identity);
			}
			position.x += 0.5f;
		}

	}

}
