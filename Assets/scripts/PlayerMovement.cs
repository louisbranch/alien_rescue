using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float hSpeed = 5f;
	public float vForce = 400f;

	private bool isFacingRight = true;
	private bool isGrounded = false;
	private bool isClimbing = false;

	public Transform groundChecker;
	public float groundedRadius = 0.2f;
	public LayerMask groundLayer;

	Animator anim;

	private void Awake () {
		anim = GetComponent<Animator>();
	}

	private void Update () {

		isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundedRadius, groundLayer);
		anim.SetBool("Grounded", isGrounded);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			anim.SetBool("Grounded", false);
			anim.SetFloat("VSpeed", rigidbody2D.velocity.y);
			rigidbody2D.AddForce(new Vector2(0, vForce));
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}

	}

	private void FixedUpdate () {

		if (isGrounded) {
			float move = Input.GetAxis("Horizontal");
			
			rigidbody2D.velocity = new Vector2(move * hSpeed, rigidbody2D.velocity.y);
			
			anim.SetFloat("HSpeed", Mathf.Abs(move));
			
			if (move > 0 && !isFacingRight) {
				Flip ();
			} else if (move < 0 && isFacingRight) {
				Flip ();
			}
		}

	}

	private void Flip () {
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}