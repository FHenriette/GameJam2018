using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleflow : MonoBehaviour {

	public static int whoseTurn = 1;
	public CapsuleCollider col;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (whoseTurn == 2) {
			var cols = Physics.OverlapSphere (col.transform.position, col.radius, LayerMask.GetMask ("Enemy"));
			foreach (Collider c in cols)
				c.GetComponent<Enemy> ().EnemyTurn ();
		}
		new WaitForSeconds(2);
		whoseTurn = 1;
	}
}
