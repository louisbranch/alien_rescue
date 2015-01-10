using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float hSpeed = 5f;
  	public float vSpeed = 3f;
	public float jumpForce = 400f;

	private bool facingRight = true;
	private bool grounded = false;
  	private bool jump = false;

	public Transform movementChecker;
	public float checkerRadius = 0.1f;
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

		grounded = Physics2D.OverlapCircle(movementChecker.position, checkerRadius, groundLayer);

		anim.SetBool("Grounded", grounded);

		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}

	}

	private void FixedUpdate () {

		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		if (grounded) {
			rigidbody2D.velocity = new Vector2(hMove * hSpeed, rigidbody2D.velocity.y);
			anim.SetFloat("HSpeed", Mathf.Abs(hMove));

			if (hMove > 0 && !facingRight) {
				Flip ();
			} else if (hMove < 0 && facingRight) {
				Flip ();
			}
		}

		
		if (jump) {
			anim.SetBool("Grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			jump = false;
		} 	

	}

	void OnCollisionEnter2D(Collision2D coll){
		string layer = LayerMask.LayerToName(coll.gameObject.layer);
		if (layer == "Enemies") {
			KillPlayer();
		}
	}

	private void Flip () {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

  	//TODO move to other scripts
	private void KillPlayer () {
		anim.SetTrigger("Dead");
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5f);
		foreach(Collider2D c in GetComponents<Collider2D> ()) {
			c.enabled = false;
		}
	}

}
