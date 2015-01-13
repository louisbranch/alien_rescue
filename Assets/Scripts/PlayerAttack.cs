using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float powerUpTimer = 5f;
	public GameObject weapon;

	private bool holdingWeapon = false;

	Animator anim;
	PlayerScore score;
	PlayerSounds audio;
	
	private void Awake () {
		anim = gameObject.GetComponent<Animator>();
		score = gameObject.GetComponent<PlayerScore>();
		audio =  gameObject.GetComponent<PlayerSounds>();
	}
	
	private void OnCollisionEnter2D(Collision2D coll){
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies") {
			if (holdingWeapon) {
				KillEnemy(coll.gameObject);
			} else {
				KillPlayer();
			}
		}
	}
	
	private void OnTriggerStay2D(Collider2D coll) {
		string name = coll.gameObject.name;
		if (name == "Sword") {
			EquipWeapon();
			Destroy(coll.gameObject);
		}
	}

	public bool HoldingWeapon () {
		return holdingWeapon;
	}

	private void EquipWeapon () {
		holdingWeapon = true;
		weapon.renderer.enabled = true;
		Invoke("UnequipWeapon", powerUpTimer);
		audio.PlayPowerupSound();
	}
	
	private void UnequipWeapon () {
		holdingWeapon = false;
		weapon.renderer.enabled = false;
	}

	private void KillPlayer () {
		rigidbody2D.velocity = new Vector2(0, 5f); 	// give hero a small jump kick
		rigidbody2D.gravityScale = 1;  				// add gravity back in case of being climbing
		collider2D.enabled = false;    				// allow hero to fall through anything
		GameControl.LifeLost(score.LosingScore());
		anim.SetBool("Dead", true);
		audio.PlayDeathSound();
	}
	
	private void KillEnemy (GameObject enemy) {
		int points = enemy.GetComponent<BaseEnemy>().KillForPoints();
		score.UpdateScore(points);
	}

}