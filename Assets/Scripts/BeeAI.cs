using UnityEngine;
using System.Collections;

public class BeeAI : MonoBehaviour {

	public float speed = 0.5f;
	public float chanceOfTurning = 0.3f;
	
	private bool facingRight = true;
	
	private void Update () {	
		if (facingRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}	
	}

	private void ChangeOrientation() {
		if (Random.value < chanceOfTurning) {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll){
		string name = coll.gameObject.name;
		if (name == "ScreenLimit") {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;
		}
	}

}
