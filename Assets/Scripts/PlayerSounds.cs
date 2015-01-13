using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {

	public AudioClip[] footsteps;
	public AudioClip jumpBonus;
	public AudioClip death;

	public bool playFootstep = false;

	private float footstepRate = 0.2f;
	private float footstepCounter;
	private AudioSource source;

	private void Awake() {
		source = gameObject.GetComponent<AudioSource>();
		footstepCounter = Time.time;
	}

	private void Update() {
		if (playFootstep && (Time.time - footstepCounter) > footstepRate) {
			PlayFootStepSound ();
			playFootstep = false;
			footstepCounter = Time.time;
		}
	}

	private void PlayFootStepSound () {
		int i = Random.Range(0, footsteps.Length);
		AudioClip sound = footsteps[i];
		source.PlayOneShot(sound, 0.2f);
	}

	public void PlayJumpBonusSound() {
		source.PlayOneShot(jumpBonus);
	}

	public void PlayDeathSound() {
		source.PlayOneShot(death);
	}

}
