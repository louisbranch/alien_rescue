using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float powerUpTimer = 5f;
	public GameObject weapon;

	private bool holdingWeapon = false;
	private int killingBonus = 1;
	private float lastKill = 0f;

	Animator anim;
	
	public void Awake () {
		anim = gameObject.GetComponent<Animator>();
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
	}
	
	private void UnequipWeapon () {
		holdingWeapon = false;
		weapon.renderer.enabled = false;
	}

	private void KillPlayer () {
		rigidbody2D.velocity = new Vector2(0, 5f); 	// give hero a small jump kick
		rigidbody2D.gravityScale = 1;  				// add gravity back in case of being climbing
		collider2D.enabled = false;    				// allow hero to fall through anything
		GameControl.LifeLost();
		anim.SetBool("Dead", true);
	}
	
	private void KillEnemy (GameObject enemy) {
		//TODO add score
		int points = enemy.GetComponent<BaseEnemy>().KillForPoints();
	}

}
