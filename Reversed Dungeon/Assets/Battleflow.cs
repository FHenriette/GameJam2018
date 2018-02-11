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
			var cols = Physics.OverlapSphere(col.transform.position, 20f,LayerMask.GetMask("Enemy"));
			foreach (Collider c in cols) {
				Debug.Log (c.name);
				c.GetComponent<Enemy>().EnemyTurn();
			}

			new WaitForSeconds(2);
			Debug.Log("done");
			whoseTurn = true;
		}
	}
}
