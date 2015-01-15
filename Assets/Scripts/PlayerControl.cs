using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public float hSpeed = 5f;
  	public float vSpeed = 3f;
	public float jumpForce = 400f;
	
	private bool facingRight = true;
	private bool grounded = false;
  	private bool jump = false;

	public Transform movementChecker;
	public float checkerRadius = 0.1f;
	public LayerMask groundLayer;

	private bool atLadder = false;
	private bool atLadderEnd = false;
	
	Player player;

	private void Awake () {
		player = GetComponent<Player>();
	}

	private void Update () {

		float vMove = Input.GetAxis("Vertical");

		grounded = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, groundLayer);

		player.anim.SetBool("Grounded", grounded);

		if (Input.GetButtonDown("Jump") && grounded && !player.attack.HoldingWeapon()) {
			jump = true;
		}

		if (vMove != 0 && !player.attack.HoldingWeapon()) {
			Climb (vMove);
		}

	}

	private void FixedUpdate () {

		float hMove = Input.GetAxis("Horizontal");
	
		if (grounded && !Climbing()) {
			rigidbody2D.velocity = new Vector2(hMove * hSpeed, rigidbody2D.velocity.y);
			player.anim.SetFloat("HSpeed", Mathf.Abs(hMove));

			if (hMove > 0 && !facingRight) {
				Transform2D.FlipX(gameObject);
				facingRight = !facingRight;

			} else if (hMove < 0 && facingRight) {
				Transform2D.FlipX(gameObject);
				facingRight = !facingRight;
			}
		}
		
		if (jump) {
			player.anim.SetBool("Grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			player.sounds.PlayJumpSound();
			jump = false;
		} 	

	}
	
	private void OnTriggerEnter2D(Collider2D coll) {
		switch(coll.gameObject.name) {
		case "Ladder":
			atLadder = true;
			break;	
		case "LadderEnds":
			atLadderEnd = true;
			break;
		}
	}
	
	private void OnTriggerExit2D(Collider2D coll) {
		switch(coll.gameObject.name) {
		case "Ladder":
			StopClimb();
			break;
		case "LadderEnds":
			atLadderEnd = false;
			break;
		}
	}

	public bool GoingDown() {
		return Input.GetAxis("Vertical") < 0;
	}

	// Kinematic is only disabled during vertical moment
	public bool Climbing() {
		return rigidbody2D.isKinematic;
	}

	public bool MidAir() {
		return rigidbody2D.velocity.y != 0;
	}

	private void StopClimb () {
		atLadder = false;
		rigidbody2D.isKinematic = false;
		player.anim.SetBool("Climbing", false);		
	}

	private void Climb (float vMove) {
		if (atLadder && !MidAir()) {					    // allows climbing if hero is not jumping/falling
			rigidbody2D.isKinematic = true;					// disable gravity to allow static Y-axis movement
			rigidbody2D.velocity = new Vector2(0, 0);		// cancel any current velocity
			player.anim.SetBool("Climbing", true);
			if (vMove > 0) {
				transform.Translate (Vector2.up * vSpeed * Time.deltaTime);
				atLadderEnd = false;
			} else if (atLadderEnd && grounded) {
				StopClimb();
			} else {
				transform.Translate (-Vector2.up * vSpeed * Time.deltaTime);
			}
		}
	}

}