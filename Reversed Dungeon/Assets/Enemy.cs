using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//Stats of a character
	public int startHealth = 50; //Starting Health
	public int currentHealth; //Current Health, change this over the course of the game
	public int startMana = 0; //Starting Mana
	public int currentMana; //Current Mana, change this over the course of the game
	public int startArmor = 0; //Starting Armor
	public int currentArmor; //Current Armor, change this over the course of the game
	public int startAttack = 5; //Starting damage
	public int currentAttack; //Current damage, change this over the course of the game

	public int Levels;

	//Action Points
	public float startMP = 2.5f; //MP = Movement Points
	public float currentMP; //MP = Movement Points, change this over the course of the game
	public float startAP = 1f; //AP = Attack Points
	public float currentAP; //AP = Attack Points, change this over the course of the game

	//Turn
	public int turn;

	//Deadsies
	bool EnemyisDead = false;

	bool playerInRange = false;

	// Use this for initialization
	void Start () {

		currentAttack = startAttack;
		currentArmor = startArmor;
		currentHealth = startHealth;
		currentMP = startMP;
		currentAP = startAP;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		public void takeDamage(int damage){

			currentHealth =- (damage - currentArmor);

		}
*/
	}

	//When next movement is a player, then player is in range, if not player will not be in range. duurh
	/*public void onTriggerEnter(){

		if (gameObject == Player) {
			playerInRange = true;
		}
		if (gameObject != Player) {
			playerInRange = false;
		}
	}

	public void EnemyAttack(){

		if (playerInRange = true) {
			if (Player.currentHealth > 0) {
				Player.currentHealth -= Enemy.currentAttack;
			}
		}
	}
		

	public void enemyLevelUp(){
		Enemy.currentHealth =+ 10;
		Enemy.currentAttack = +2;
		Enemy.currentAP =+ 0.25f;
		Enemy.currentMP = +0.5f;
	}

	public void EnemyDeath(){

		if (Enemy.currentHealth <= 0) {
			EnemyisDead = true;
			GameObject.DestroyObject;
		}

	}

	public void setEnemyLevel(){

		//Supposed to set the enemy level by comparing it to the players level
		var levelArray = new ArrayList(Player.currentLevel -1, Player.currentLevel, Player.currentLevel +1);
		Levels = levelArray [Random.Range (0.2)];

		EnemyLevel = Levels;

	}*/

	public void EnemyTurn(){

		Vector3 pos = FindObjectOfType<CharControl> ().transform.position;

		for (int i = 0; i < startMP; i++) {

			float left = Mathf.Pow (Mathf.Sqrt ((transform.position.x - 1 - pos.x) + (transform.position.y - pos.y)),2),
				right = Mathf.Pow (Mathf.Sqrt ((transform.position.x + 1 - pos.x) + (transform.position.y - pos.y)),2),
				up = Mathf.Pow (Mathf.Sqrt ((transform.position.x - pos.x) + (transform.position.y + 1 - pos.y)),2),
				down = Mathf.Pow (Mathf.Sqrt ((transform.position.x - pos.x) + (transform.position.y - 1 - pos.y)),2);
		
			if ((transform.position.x - 1 == pos.x && transform.position.y == pos.y) ||
			   (transform.position.x + 1 == pos.x && transform.position.y == pos.y) ||
			   (transform.position.x == pos.x && transform.position.y + 1 == pos.y) ||
			   (transform.position.x == pos.x && transform.position.y - 1 == pos.y)) {
				break;
			}

			if (left < right && left < up && left < down) {
				transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
			} else if (right < left && right < up && right < down) {
				transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
			} else if (up < right && up < left && up < down) {
				transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
			} else if (down < right && down < left && down < up) {
				transform.position = new Vector3(transform.position.x, transform.position.y-1, transform.position.z);
			}
		
		}

		for (int i = 0; i < startAP; i++) {
			if ((transform.position.x - 1 == pos.x && transform.position.y == pos.y) ||
				(transform.position.x + 1 == pos.x && transform.position.y == pos.y) ||
				(transform.position.x == pos.x && transform.position.y + 1 == pos.y) ||
				(transform.position.x == pos.x && transform.position.y - 1 == pos.y)) {
				FindObjectOfType<Player> ().currentHealth -= (startAttack - FindObjectOfType<Player> ().currentArmor);
			}
		}
	
	}

}
