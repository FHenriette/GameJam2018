using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public List<GameObject> Enemies;


	public void GenerateEnemies(int n, Room r){
		for (int x = r.x+1; x < r.x + r.width-1; x++) {
			for (int y = r.y+1; y < r.y + r.height-1; y++) {
				if (n == 0)
					break;
				else {
					if (Random.Range (0, 20) == 0) {
						Instantiate (Enemies [Random.Range (0, Enemies.Count)], new Vector3 (x, y, 0), Quaternion.identity);
						n--;
					}
				}
			}
		}
	}
}
