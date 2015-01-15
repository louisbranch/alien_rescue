using UnityEngine;
using System.Collections;

public class KeepAlive : MonoBehaviour {

	private static bool playing = false;
	
	private void Awake () {
		if (playing) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
			playing = true;
		}

	}

}
