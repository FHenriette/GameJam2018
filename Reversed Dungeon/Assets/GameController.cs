using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public RoomGenerator generator;
	public EnemyGenerator enemygen;
	public GameObject Jerry;
	public UIControl UI;
	private Room room;

	public void Init(){
		UI.MainMenu.gameObject.SetActive (false);
		UI.InGameUI.gameObject.SetActive (true);
		StartGame ();
	}

	void StartGame(){
		Room r = generator.GenerateRooms (20, 5, 5, 15, 15);
		room = r;
		Camera.main.transform.parent = Jerry.transform;
		Jerry.transform.position = new Vector3 (r.x + r.width / 2, r.y + r.height / 2, Jerry.transform.position.z);
		Jerry.SetActive (true);
		SpawnEnemies ();
	}

	void SpawnEnemies(){
		HashSet<Room> visited = new HashSet<Room> ();
		Queue<Room> rooms = new Queue<Room> ();
		visited.Add (room);
		foreach (Door d in room.doors.Values) {
			if (d != null) {
				if (d.r2 != null) {
					rooms.Enqueue (d.r2);
				}

			}
		}

		while (rooms.Count > 0) {
			Room r = rooms.Dequeue ();
			visited.Add (r);
			enemygen.GenerateEnemies (Random.Range (4, 8), r);
			foreach (Door d in r.doors.Values) {
				if (d != null) {
					if (d.r2 != null && !visited.Contains(d.r2)) {
						rooms.Enqueue (d.r2);
					}

				}
			}
		}
	}


	public void MenuToControls(){
		UI.MenuButtons.SetActive (false);
		UI.ControlsOverview.gameObject.SetActive (true);
	}

	public void ControlsToMenu(){
		UI.ControlsOverview.gameObject.SetActive (false);
		UI.MenuButtons.SetActive (true);
	}

	public void MenuToCredits(){
		UI.MenuButtons.SetActive (false);
		UI.Credits.gameObject.SetActive (true);
	}

	public void CreditsToMenu(){
		UI.Credits.gameObject.SetActive (false);
		UI.MenuButtons.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
