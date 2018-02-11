using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]
public class Sounds : MonoBehaviour {

	public AudioClip Spell;
	public AudioClip Ranged;
	public AudioClip Melee;
	public AudioClip GetHit;
	public AudioClip LevelUp;
	public AudioClip EnemyAttack;

	AudioSource audioSource;

	public float volume;

 	void Start(){

		audioSource = GetComponent<AudioSource> ();

	}

	void Update () {
		
		if (Input.GetKeyDown ("1")) {
			audioSource.clip = Melee;
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("2")) {
			audioSource.clip = Ranged;
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("3")) {
			audioSource.clip = Spell;
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("4")) {
			audioSource.clip = GetHit;
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("5")) {
			audioSource.clip = LevelUp;
			audioSource.Play ();
		}
		if (Input.GetKeyDown ("6")) {
			audioSource.clip = EnemyAttack;
			audioSource.volume = 0.2f;
			audioSource.Play ();
		}

	}
}


