using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float movementSpeed = 3.0f;

	private void Update () {
		Vector3 scale = transform.localScale;
		Vector3 pos = transform.position;

		float speed = Time.deltaTime * movementSpeed;
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			scale.x = -1;
			pos.x -= speed;
			transform.localScale = scale;
			transform.position = pos;
		} 
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			scale.x = 1;
			pos.x += speed;
			transform.localScale = scale;
			transform.position = pos;
		} 
		
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//TODO
		} 
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//TODO
		}
	}

}