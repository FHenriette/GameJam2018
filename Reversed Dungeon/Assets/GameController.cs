using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public RoomGenerator generator;
	public GameObject Jerry;

	void Start(){
		Room r = generator.GenerateRooms (20, 5, 5, 15, 15);
		Jerry.transform.position = new Vector3 (r.x + r.width / 2, r.y + r.height / 2, Jerry.transform.position.z);
		Jerry.SetActive (true);
	}

}
