using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CharControl : MonoBehaviour {

	public int speed = 1;
	public int moves, attacks;
	public Collider[] hitboxes;


	// Use this for initialization
	void Start () {
		// Moves the object that the script is connected to
        //transform.position = new Vector3(0, 0, 0);
	}


	void Update () {

		movement ();
	}


	// Controls movement of character.
	private void movement(){

		// Create bools for movement
		bool[] axis = new bool[4];
		for (int i = 0; i < 4; i++)
			axis[i] = true;

		// Check for surrounding cubes for 
		for (int i = 0; i < 4; i++) {
			var cols = Physics.OverlapBox (hitboxes[i].bounds.center, hitboxes[i].bounds.extents, hitboxes[i].transform.rotation, LayerMask.GetMask ("Obstacle"));

			foreach (Collider c in cols){
				axis [i] = false;
			}
		}

		// move up if 'w' is pressed
		if (axis[0] && Input.GetKeyDown("w"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
		}
		// move down is 's' is pressed
		if (axis[1] && Input.GetKeyDown("s"))
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - speed, 0);
		}
		// move left if 'a' is pressed
		if (axis[2] && Input.GetKeyDown("a"))
		{
			transform.position = new Vector3 (transform.position.x - speed, transform.position.y, 0);
		}
		// move right if 'd' is pressed
		if (axis[3] && Input.GetKeyDown("d"))
		{
			transform.position = new Vector3 (transform.position.x + speed, transform.position.y, 0);
		}

	}
}
