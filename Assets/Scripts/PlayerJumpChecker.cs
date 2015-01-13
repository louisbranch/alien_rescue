using UnityEngine;
using System.Collections;

public class PlayerJumpChecker : MonoBehaviour {

	public float bonusTimeLimit = 2f;
	public GameObject hero;
	
	Player player;

	private float counter = 0;
	private int bonus = 0;

	private void Awake () {
		player = hero.GetComponent<Player>();
	}

	private void Update() {
		if (counter > 0 && (Time.time - counter) > bonusTimeLimit) {
			bonus = 0;
			counter = 0;
		}
	}

	private void OnTriggerExit2D (Collider2D coll) {
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies" && !player.Dead() && player.MidAir()) {
			++bonus;
			KillEnemy(coll.gameObject);
			counter = Time.time;
			player.sounds.PlayJumpBonusSound();
		}
	}

	private void KillEnemy (GameObject enemy) {
		int points = enemy.GetComponent<BaseEnemy>().JumpForPoints();
		player.score.UpdateScore(points * bonus);
	}

}
