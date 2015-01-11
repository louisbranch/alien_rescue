using UnityEngine;
using System.Collections;

public class BeeAI : MonoBehaviour {

	public float speed = 0.5f;
	public float chanceOfTurning = 0.3f;
	
	private bool facingRight = true;
	private bool ready = false;
	
	private void Update () {	
		if (facingRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}	
	}

	private void ChangeOrientation() {
		if (ready && Random.value < chanceOfTurning) {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll){
		string name = coll.gameObject.name;
		if (name == "ScreenLimit" || (name == "Pipe" && ready)) {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;
		} else if (name == "Platform" && !ready) {
			ready = true;
			InvokeRepeating("ChangeOrientation", 2, 1.0f);
		}
	}

}
