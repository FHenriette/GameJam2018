using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleflow : MonoBehaviour {

	public static bool whoseTurn = true;
	public SphereCollider col;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!whoseTurn) {
			Debug.Log ("Checks");
			var cols = Physics.OverlapSphere (col.transform.position, col.radius, LayerMask.GetMask ("Enemy"));
			foreach (Collider c in cols) {
				c.GetComponent<Enemy> ().EnemyTurn ();
				Debug.Log ("found enemy");
			}
			new WaitForSeconds(2);
			Debug.Log("done");
			whoseTurn = true;
		}
	}
}
