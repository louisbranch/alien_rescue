using UnityEngine;
using System.Collections;

public class EndPointChecker : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D coll) {
		GameObject obj = coll.gameObject;
		if (obj.name == "Hero") {
			PlayerScore score = obj.GetComponent<PlayerScore>();
			GameControl.WinLevel(score.WinningScore());
		}
	}
}