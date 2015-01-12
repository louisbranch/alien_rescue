using UnityEngine;
using System.Collections;

public class RandomCollider : MonoBehaviour {

	public float collisionSkipRate = 0.3f;

	private void OnCollisionEnter2D(Collision2D coll) {
		string name = coll.gameObject.name;
		if (name == "Spinner") {
			if (Random.value < collisionSkipRate) {
				Physics2D.IgnoreCollision(collider2D, coll.collider, true);
			}
		}
	}
}
