using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemy;
	private GameObject clone;
	
	private void OnTriggerEnter2D(Collider2D coll){
		string name = coll.gameObject.name;
		if (name == "Spinner") {
			Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); 
			GameObject clone = (GameObject)Instantiate(enemy, newPosition, Quaternion.identity);
			clone.name = enemy.name;
			clone.rigidbody2D.AddForce(new Vector2(200f, 0));
			Destroy(coll.gameObject);
		}
	}
}
