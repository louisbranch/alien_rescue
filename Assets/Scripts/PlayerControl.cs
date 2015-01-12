using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public float hSpeed = 5f;
  	public float vSpeed = 3f;
	public float jumpForce = 400f;

	public GameObject sword;

	private bool facingRight = true;
	private bool grounded = false;
  	private bool jump = false;
	private bool atLadder = false;
	private bool holdingSword = false;

	public Transform movementChecker;
	public float checkerRadius = 0.1f;
	public LayerMask groundLayer;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	private void Update () {

		float vMove = Input.GetAxis("Vertical");

		grounded = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, groundLayer);

		anim.SetBool("Grounded", grounded);

		if (Input.GetButtonDown("Jump") && grounded && !holdingSword) {
			jump = true;
		}

		if (vMove != 0 && !holdingSword) {
			Climb (vMove);
		}

	}

	private void FixedUpdate () {

		float hMove = Input.GetAxis("Horizontal");
	
		if (grounded) {
			rigidbody2D.velocity = new Vector2(hMove * hSpeed, rigidbody2D.velocity.y);
			anim.SetFloat("HSpeed", Mathf.Abs(hMove));

			if (hMove > 0 && !facingRight) {
				Transform2D.FlipX(gameObject);
				facingRight = !facingRight;

			} else if (hMove < 0 && facingRight) {
				Transform2D.FlipX(gameObject);
				facingRight = !facingRight;
			}
		}
		
		if (jump) {
			anim.SetBool("Grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			jump = false;
		} 	

	}

	private void OnCollisionEnter2D(Collision2D coll){
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies") {
			if (holdingSword) {
				KillEnemy(coll.gameObject);
			} else {
				KillPlayer();
			}
		}
	}

	private void OnTriggerStay2D(Collider2D coll) {
		string name = coll.gameObject.name;
		if (name == "Ladder") {
			atLadder = true;
		} else if (name == "Sword") {
			EquipSword();
			Destroy(coll.gameObject);
		}
	}
	
	private void OnTriggerExit2D(Collider2D coll) {
		string name = coll.gameObject.name;
		if (name == "Ladder") {
			atLadder = false;
			rigidbody2D.gravityScale = 1;
			anim.SetBool("Climbing", false);		
		}
	}
	
	private void KillPlayer () {
		anim.SetTrigger("Dead");
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5f);
		collider2D.enabled = false;
		GameControl.LifeLost();
	}

	private void KillEnemy (GameObject enemy) {
		//TODO add score
		Destroy(enemy);
	}

	private void Climb (float vMove) {
		float vVelo = rigidbody2D.velocity.y;
		if (atLadder && vVelo == 0) {
			rigidbody2D.gravityScale = 0;
			rigidbody2D.velocity = new Vector2(0, 0);
			anim.SetBool("Climbing", true);
			if (vMove > 0) {
				transform.Translate (Vector2.up * vSpeed * Time.deltaTime);
			} else {
				transform.Translate (-Vector2.up * vSpeed * Time.deltaTime);
			}
		}
	}

	private void EquipSword () {
		holdingSword = true;
		sword.renderer.enabled = true;
	}

}