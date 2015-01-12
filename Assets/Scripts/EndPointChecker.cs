using UnityEngine;
using System.Collections;

public class EndPointChecker : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.name == "Hero") {
			GameControl.WinLevel();
		}
	}
}
