using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door {
	public int x,y;
	public Room r1, r2;

	public Door(int _x, int _y, Room _r1){
		x = _x;
		y = _y;
		r1 = _r1;
	}

	public void SetRoom2(Room r){
		r2 = r;
	}
}
