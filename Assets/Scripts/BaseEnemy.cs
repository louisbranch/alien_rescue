using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

	public int bonusPoints = 100;

	Animator anim;

	public void Awake () {
		anim = gameObject.GetComponent<Animator>();
	}

	public int KillForPoints () {
		anim.SetTrigger("Dead");
		rigidbody2D.velocity = new Vector2(0, 5f); 	// give enemy a small bump kick
		collider2D.enabled = false;   
		return bonusPoints;
	}

}
