using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float maxSpeed = 5f;
	private bool isFacingRight = true;
	private bool isGrounded = true;
	private bool isClimbing = false;

	Animator anim;

	private void Start () {
		anim = GetComponent<Animator>();
	}

	private void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}

	}

	private void FixedUpdate () {
		//TODO check for grounded
		float move = Input.GetAxis("Horizontal");

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(move));

		if (move > 0 && !isFacingRight) {
			Flip ();
		} else if (move < 0 && isFacingRight) {
			Flip ();
		}
	}

	private void Flip () {
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}