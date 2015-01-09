using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 3.0f;
	private bool isGrounded = true;
	private bool isClimbing = false;

	private void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector3.right * speed * Time.deltaTime); 
			transform.eulerAngles = new Vector2(0, 180);
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector3.right * speed * Time.deltaTime); 
			transform.eulerAngles = new Vector2(0, 0);
		} 
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//TODO
		} 
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//TODO
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing) {
			rigidbody2D.AddForce(transform.up * 200f);
		}
	}

	private void FixedUpdate () {
		//TODO check for grounded
	}

}