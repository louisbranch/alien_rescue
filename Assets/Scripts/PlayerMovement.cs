using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float hSpeed = 5f;
	public float vSpeed = 3f;
	public float jumpForce = 400f;

	private bool isFacingRight = true;
	private bool isGrounded = false;

	public Transform movementChecker;
	public float checkerRadius = 0.2f;
	public LayerMask groundLayer;
	public LayerMask laddersLayer;

	private int PlayerLayerID;
	private int PlatformLayerID;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
		PlayerLayerID = LayerMask.NameToLayer("Player");
		PlatformLayerID = LayerMask.NameToLayer("Ground");
	}

	private void Update () {

		isGrounded = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, groundLayer);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			isGrounded = false;
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
		
		anim.SetBool("Grounded", isGrounded);

	}

	private void FixedUpdate () {

		float hMove = Input.GetAxis("Horizontal");
		//float vMove = Input.GetAxis("Vertical");

	 	if (isGrounded) {

			rigidbody2D.velocity = new Vector2(hMove * hSpeed, rigidbody2D.velocity.y);
			anim.SetFloat("HSpeed", Mathf.Abs(hMove));
			
			if (hMove > 0 && !isFacingRight) {
				Flip ();
			} else if (hMove < 0 && isFacingRight) {
				Flip ();
			}
				
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies") {
			KillPlayer();
		}
	}

	private void Flip () {
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	private void StartClimb (float vMove) {
		rigidbody2D.gravityScale = 0;
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, vMove * vSpeed);
		anim.SetFloat("VSpeed", Mathf.Abs(vMove));
	}

	private void StopClimb (float vMove) {
		rigidbody2D.gravityScale = 1;
		anim.SetFloat("VSpeed", Mathf.Abs(vMove));
	}

	private void KillPlayer () {
		anim.SetBool("IsDead", true);
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5f);
		foreach(Collider2D c in GetComponents<Collider2D> ()) {
			c.enabled = false;
		}
	}

}