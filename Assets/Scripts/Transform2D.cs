using UnityEngine;
using System.Collections;

public class Transform2D {

	public static void FlipX (GameObject obj) {
		Vector3 scale = obj.transform.localScale;
		scale.x *= -1;
		obj.transform.localScale = scale;
	}
}
