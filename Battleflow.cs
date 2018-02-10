using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleflow : MonoBehaviour {

	public static int whoseTurn = 1;
	public Collider col;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (whoseTurn == 2) {
			var cols = Physics.OverlapBox (col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask ("Enemy"));
			int alphabetium = 100000000;
		}
	}
}
