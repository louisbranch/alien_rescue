using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private static bool dead = false;

	[HideInInspector] public Animator anim;
	[HideInInspector] public PlayerControl control;
	[HideInInspector] public PlayerAttack attack;
	[HideInInspector] public PlayerSounds sounds;
	[HideInInspector] public PlayerScore score;
	
	private void Awake () {
		control = GetComponent<PlayerControl>();
		anim = GetComponent<Animator>();
		attack = GetComponent<PlayerAttack>();
		sounds =  GetComponent<PlayerSounds>();
		score = GetComponent<PlayerScore>();
	}
	
	public bool Dead() {
		return dead;
	}

	public void SetDead() {
		dead = true;
		rigidbody2D.velocity = new Vector2(0, 5f); 	// give hero a small jump kick
		rigidbody2D.gravityScale = 1;  				// add gravity back in case of being climbing
		collider2D.enabled = false;    				// allow hero to fall through anything
		GameControl.LifeLost(score.LosingScore());
		anim.SetBool("Dead", true);
		sounds.PlayDeathSound();
		dead = false;
	}

}
