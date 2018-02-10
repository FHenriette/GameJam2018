using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {
	public GameObject tile;
	public GameObject wall;
	public List<Sprite> tileTextures;
	public List<Texture> wallTextures;
	HashSet<Room> generatedRooms = new HashSet<Room>();
	// Use this for initialization
	void Start () {
		Room room = Room.GenerateRooms (20, 5, 5, 15, 15);
		Queue<Room> rooms = new Queue<Room> ();
		rooms.Enqueue (room);
		while (rooms.Count > 0) {
			Room r = rooms.Dequeue ();
			if (r == null) continue;
			if (!generatedRooms.Contains (r)) {
				GameObject rObject = new GameObject ();
				//rObject.transform.position = new Vector3 (r.x, r.y, 0);
				for (int x = r.x; x <= r.x + r.width; x++) {
					for (int y = r.y; y <= r.y + r.height; y++) {
						GameObject obj;
						if ((x == r.x || x == r.x + r.width) || (y == r.y || y == r.y + r.height)) {
							bool door = false;
							foreach (Door d in r.doors.Values) {
								if (d.r2 != null) {
									if (x == d.x && y == d.y) {
										door = true;
										break;
									}
								}
							}

							if (door) {
								Debug.Log ("Door here!");
								obj = GameObject.Instantiate (tile, new Vector3 (x, y, 0.5f), Quaternion.identity);
								obj.transform.SetParent (rObject.transform);	
								obj.GetComponent<SpriteRenderer> ().sprite = tileTextures[Random.Range(0, tileTextures.Count)];
							} else {
								obj = GameObject.Instantiate (wall, new Vector3 (x, y, 0), Quaternion.Euler(90*Random.Range(0,3),-90,90));
								obj.transform.SetParent (rObject.transform);
								obj.GetComponentInChildren<MeshRenderer>().material.mainTexture = wallTextures[Random.Range(0, wallTextures.Count)];
							}
						} else {
							obj = GameObject.Instantiate (tile, new Vector3 (x, y, 0.5f), Quaternion.identity);
							obj.transform.SetParent(rObject.transform);
							obj.GetComponent<SpriteRenderer>().sprite = tileTextures[Random.Range(0, tileTextures.Count)];
						}
					}
				}
				foreach (Door dr in r.doors.Values) {
					rooms.Enqueue (dr.r2);
				}
				generatedRooms.Add (r);
			}
		}
	}
}
