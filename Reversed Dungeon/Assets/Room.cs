using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { NORTH, EAST, SOUTH, WEST }

public class Room {
	
	public int x, y, width, height;
	public Dictionary<Direction, Door> doors;

	public Room(int _x, int _y, int _width, int _height){
		x = _x;
		y = _y;
		width = _width;
		height = _height;
	}

	private bool CollidesWith(Room other){
		return (x < other.x + other.width) && (x + width > other.x) && (y < other.y + other.height) && (y + height > other.y); 
	}

	private static Direction GetOpposite(Direction d){
		switch (d) {
		case(Direction.NORTH):
			return Direction.SOUTH;
		case(Direction.EAST):
			return Direction.WEST;
		case(Direction.SOUTH):
			return Direction.NORTH;
		case(Direction.WEST):
			return Direction.EAST;
		default:
			throw new UnityException ("IDIOT");
		}
	}

	private static Dictionary<Direction, Door> GenerateDoors(Room origin){
		Dictionary<Direction, Door> drs = new Dictionary<Direction, Door> ();
		int x = Random.Range (origin.x+1, origin.x + origin.width-1);
		int y = Random.Range (origin.y+1, origin.y + origin.height-1);
		drs.Add (Direction.NORTH, new Door(x, origin.y+origin.height, origin));
		drs.Add (Direction.EAST, new Door(origin.x+origin.width, y, origin));
		drs.Add (Direction.SOUTH, new Door(x, origin.y, origin));
		drs.Add (Direction.WEST, new Door(origin.x, y, origin));
		return drs;
	}

	private static bool CollidesWith(Room r, HashSet<Room> rooms){
		foreach (Room rm in rooms) {
			if (r.CollidesWith (rm))
				return true;
		}
		return false;
	}

	private static Room GenerateRoom(int x, int y, int minWidth, int minHeight, int maxWidth, int maxHeight, Direction dir, HashSet<Room> generatedRooms) {
		int dx, dy, w, h;
		w = Random.Range (minWidth, maxWidth);
		h = Random.Range (minHeight, maxHeight);
		dx = x;
		dy = y;
		if(dir == Direction.SOUTH) dy -= h;
		else if (dir == Direction.WEST) dx -= w;

		Room r = new Room (dx, dy, w, h);
		if (!CollidesWith (r, generatedRooms)) return r; //Room fits
		//resize to minimum size
		r.width = minWidth;
		r.height = minHeight;
		if(CollidesWith(r,generatedRooms)) return null; //Smallest room does not fit, drop it
		//checkes for height and width increment
		bool incW = true, incH = true;
		while(incW || incH){ //try to increase the size and make the room as big as possible (given by previous width and height)
			if(r.width == w) incW = false;
			if (r.height == h) incH = false;
			if(incW){
				r.width++;
				if(dir == Direction.WEST) r.x = x - r.width;
				if(CollidesWith(r, generatedRooms)){
					r.width--;
					if(dir == Direction.WEST) r.x = x - r.width;
					incW = false;
				}
			}
			if (incH) {
				r.height++;
				if(dir == Direction.SOUTH) r.y = y - r.height;
				if (CollidesWith (r, generatedRooms)) {
					r.height--;
					if(dir == Direction.SOUTH) r.y = y - r.height;
					incH = false;
				}
			}
		}
		if (!CollidesWith (r, generatedRooms))
			return r;
		else
			return null;
	}

	public static Room GenerateRooms(int n, int minWidth, int minHeight, int maxWidth, int maxHeight){
		Queue<Room> rooms = new Queue<Room>();
		HashSet<Room> generatedRooms = new HashSet<Room> ();
		Room first = GenerateRoom (0, 0, minWidth, minHeight, maxWidth, maxHeight, Direction.NORTH, generatedRooms);
		Debug.Log (first);
		first.doors = GenerateDoors (first);;
		generatedRooms.Add (first);
		n--;
		rooms.Enqueue (first);
		while (n > 0) {
			Room room = rooms.Dequeue ();
			for (int d = 0; d < 4; d++) {
				Direction dir = (Direction)d;
				if (room.doors [dir].r2 == null && n > 0) {
					Room newRoom;
					switch (dir) {
					case(Direction.NORTH):
						newRoom = GenerateRoom (room.doors[Direction.NORTH].x-2, room.y+room.height, minWidth, minHeight, maxWidth, maxHeight, dir, generatedRooms);
						break;
					case(Direction.EAST):
						newRoom = GenerateRoom (room.x+room.width, room.doors[Direction.EAST].y-2, minWidth, minHeight, maxWidth, maxHeight, dir, generatedRooms);
						break;
					case(Direction.SOUTH):
						//WRONG HERE! Should generate a new room with x and y and determine from which direction it is created!
						newRoom = GenerateRoom (room.doors[Direction.SOUTH].x-2, room.y, minWidth, minHeight, maxWidth, maxHeight, dir, generatedRooms);
						break;
					case(Direction.WEST): //WEST
						newRoom = GenerateRoom (room.x, room.doors[Direction.WEST].y-2, minWidth, minHeight, maxWidth, maxHeight, dir, generatedRooms);
						break;
					default:
						throw new UnityException ("IDIOT");
					}
					if (newRoom != null) {
						newRoom.doors = GenerateDoors (newRoom);
						//New room is connected to the current room
						newRoom.doors[GetOpposite(dir)] = room.doors[dir];
						newRoom.doors[GetOpposite(dir)].SetRoom2(newRoom);
						generatedRooms.Add (newRoom);
						room.doors[dir].SetRoom2(newRoom);
						rooms.Enqueue (newRoom);
						n--;
					}
				}
			}
		}
		return first;
	}
}
