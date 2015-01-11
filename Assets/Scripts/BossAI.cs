using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public GameObject enemy;
	private GameObject clone;
	private bool facingRight = true;
	public float speed = 1.0f;
	
	private void Update () {

		if (facingRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}

	}

	private void OnCollisionEnter2D(Collision2D coll){
		string name = coll.gameObject.name;
		if (name == "Boxes") {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;
		}
	}

	private void OnTriggerEnter2D(Collider2D coll){
		string name = coll.gameObject.name;
		if (name == "Ladder") {
			Transform2D.FlipX(gameObject);
			facingRight = !facingRight;

			Vector3 newPosition = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z); 
			clone = (GameObject)Instantiate(enemy, newPosition, Quaternion.identity);
			clone.name = enemy.name;
			clone.rigidbody2D.AddForce(new Vector2(200f, 0));
		}
	}
}
