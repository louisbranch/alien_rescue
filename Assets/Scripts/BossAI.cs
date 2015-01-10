using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public GameObject minion;
	private GameObject spawnedMinion;
	private bool facingRight = true;
	public float speed = 1.0f;
	
	void Update () {

		if (facingRight) {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		} else {
			transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}

	}

	private void OnCollisionEnter2D(Collision2D coll){
		string name = coll.gameObject.name;
		if (name == "Boxes") {
			Flip();
		}
	}

	private void OnTriggerEnter2D(Collider2D coll){
		string name = coll.gameObject.name;
		if (name == "Ladder") {
			Flip();

			Vector3 newPosition = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z); 
			spawnedMinion = (GameObject)Instantiate(minion, newPosition, Quaternion.identity);
			spawnedMinion.rigidbody2D.AddForce(new Vector2(400f, 0));
		}
	}

	private void Flip () {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
