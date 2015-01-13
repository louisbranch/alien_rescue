using UnityEngine;
using System.Collections;

public class PlayerJumpChecker : MonoBehaviour {

	public float bonusTimeLimit = 2f;
	public GameObject player;
	
	PlayerScore score;

	private float counter = 0;
	private int bonus = 0;

	private void Awake () {
		score = player.GetComponent<PlayerScore>();
	}

	private void Update() {
		if (counter > 0 && (Time.time - counter) > bonusTimeLimit) {
			bonus = 0;
			counter = 0;
		}
	}

	private void OnTriggerExit2D (Collider2D coll) {
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies" && player.collider2D.enabled) {
			++bonus;
			KillEnemy(coll.gameObject);
			counter = Time.time;
		}
	}

	private void KillEnemy (GameObject enemy) {
		int points = enemy.GetComponent<BaseEnemy>().JumpForPoints();
		score.UpdateScore(points * bonus);
	}

}
