using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour {

	public Collider2D platformCollider;

	private void OnTriggerEnter2D(Collider2D coll){
		string name = coll.gameObject.name;
		if (name == "Hero") {
			Physics2D.IgnoreCollision(platformCollider, coll, true);
		}
	}

	private void OnTriggerExit2D(Collider2D coll){
		string name = coll.gameObject.name;
		if (name == "Hero") {
			Physics2D.IgnoreCollision(platformCollider, coll, false);
		}
	}
}
