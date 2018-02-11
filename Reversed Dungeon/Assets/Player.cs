using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Stats of a character
	public int startHealth = 100; //Starting Health
	public int currentHealth; //Current Health, change this over the course of the game
	public int startMana = 15; //Starting Mana
	public int currentMana; //Current Mana, change this over the course of the game
	public int startArmor = 0; //Starting Armor
	public int currentArmor; //Current Armor, change this over the course of the game
	public int startAttack = 10; //Starting damage
	public int currentAttack; //Current damage, change this over the course of the game

	//Action Points
	public float startMP = 3; //MP = Movement Points
	public float currentMP; //MP = Movement Points, change this over the course of the game
	public float startAP = 1; //AP = Attack Points
	public float currentAP; //AP = Attack Points, change this over the course of the game

	public float newLevelExp = 100;
	public int currentExp = 0;
	public int startLevel = 1;
	public int currentLevel;
	//public int killExp = (15+(Enemy.Levels *2));
	public int score;

	public int speed = 1;

	//Turn
	public int turn;

	//Attacks
	public bool melee = true;
	public bool ranged = false;
	public bool spell = false;

	//Deadsies
	public bool isDead = false;

	// used for hitboxes
	public Collider[] hitboxes;

	// Use this for initialization
	void Start () {

		currentAttack = startAttack;
		currentArmor = startArmor;
		currentHealth = startHealth;
		currentMana = startMana;
		currentMP = startMP;
		currentAP = startAP;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead) {
			if (Battleflow.whoseTurn) {
				movement ();
			}

			PlayerGainExp ();

			if (currentHealth <= 0) {
				score = currentExp;
			}
		}
			
		checkDeath ();
	}

	//Function for when dead - What to do and reset.
	public void checkDeath(){
		if (currentHealth <= 0) {
			isDead = true; 
		}
	}

	public void PlayerAttack(){

	}


	public void playerLevelUp(){
		newLevelExp *= 1.5f;
		currentHealth  =+ 20;
		currentMana =+ 5;
		currentAttack =+ 5;
		currentAP += 0.5f;
		currentMP += 0.5f;
		//PlayerAbilities.PlayerGenes ();

		//EnemyAbilities.enemyLevelUp ();
	}

	public void PlayerGainExp(){ //This one is constant, so should be in update. Should also just stand alone
		//outside of a void itself

		/*if (enemy gameObject == Enemy.isDead) { //This obviously aint done
			currentHealth += 10;
			if (Enemy.Levels < Player.currentLevel) {
				Player.currentExp += killExp;
			} 
			else if (Enemy.Levels == Player.currentLevel) {
				Player.currentExp += killExp;
			} 
			else if (Enemy.Levels > Player.currentLevel) {
				Player.currentExp += killExp;
			}
		}

		if (Player.currentExp >= newLevelExp) {
			playerLevelUp ();
		}*/
	}

	public void PlayerAttacks (){
		
		/*int damage = currentAttack;

		//These 3 specifies which attack you want toggled
		if (Input.GetKeyDown ("1")) { 
			print ("Melee attack is now toggled");
			damage = currentAttack;
			melee = true;
			ranged = false;
			spell = false;
		}
		if (Input.GetKeyDown ("2")) {
			print ("Ranged attack is now toggled");
			damage *= 0.75;
			melee = false;
			ranged = true;
			spell = false;
		}
		if (Input.GetKeyDown ("3")) {
			print ("Spell is now toggled");
			damage *= 1.50f;
			melee = false;
			ranged = false;
			spell = true;
		}
		if (Input.GetMouseButtonDown (0 || 1 || 2)) {
			print (BattleFlow.enemies [i] + " has been targeted");
			//tags the enemy with left, right, middle mouse click.
		}
		if (Input.GetKeyDown ("enter")) {
			print ("Turn Ending");
			turn++; // 
		}
		//What happens when attacking
		if (Input.GetKeyDown ("space")) {
			if (Player.currentAP > 0) {
				print ("I stab at thee");
				if (melee = true) {
					Attack ();
					Player.currentAP = -1;
				}
				if (ranged = true) {
					Attack ();
					Player.currentAP = -1;
				}
				if (spell = true) {
					Attack ();
					Player.currentMana = -5;
					Player.currentAP = -1;
				}
			}
		}
	}

	public void PlayerGenes(){

		if (currentLevel == 2 ||currentLevel ==  4 ||currentLevel ==  6 ||currentLevel ==  8 ||currentLevel ==  10 ||currentLevel ==  12) {

			int value = Random.Range (1, 13);
			if (value == 1 || value ==  5 || value == 9) {
				print ("Scaly Hide have been evolved");
				currentHealth += 30;
				currentArmor += 2;
			}
			if (value == 2 || value == 6 || value == 10) {
				print ("Claws have been evolved");
				currentAttack += 10;
				currentHealth += 10;
			}
			if (value == 3 || value == 7 || value == 11) {
				print ("Magic Aura have been evolved");
				currentHealth += 20;
				currentArmor += 2;
				currentMana += 10;
			}
			if(value == 4 || value == 8 || value == 12) {
				print ("Shooting Spikes have been evolved");
				currentAttack += 5;
				currentArmor += 2;
			}
		}*/
	}

	// Controls movement of character.
	private void movement(){
		if (currentMP > 0) {
			// Create bools for movement
			bool[] axis = new bool[4];
			for (int i = 0; i < 4; i++)
				axis [i] = true;

			for (int i = 0; i < 4; i++) {
				//check for surrounding obstacles
				var cols = Physics.OverlapBox (hitboxes [i].bounds.center, hitboxes [i].bounds.extents, hitboxes [i].transform.rotation, LayerMask.GetMask ("Obstacle"));
				foreach (Collider c in cols)
					axis [i] = false;
				//check for surrounding enemies
				var newcols = Physics.OverlapBox (hitboxes [i].bounds.center, hitboxes [i].bounds.extents, hitboxes [i].transform.rotation, LayerMask.GetMask ("Enemy"));
				foreach (Collider c in newcols)
					axis [i] = false;
			}

			// move up if 'w' is pressed
			if (axis [0] && Input.GetKeyDown ("w")) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + speed, 0);
				currentMP -= 1;
			} else if (axis [1] && Input.GetKeyDown ("s")) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - speed, 0);
				currentMP -= 1;
			} else if (axis [2] && Input.GetKeyDown ("a")) {
				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, 0);
				currentMP -= 1;
			} else if (axis [3] && Input.GetKeyDown ("d")) {
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, 0);
				currentMP -= 1;
			}
		}
	}

	public void endTurn(){
		//Reset counters
		currentMP = startMP;
		currentAP = startAP;
		//change to AI turn
		Battleflow.whoseTurn = !Battleflow.whoseTurn;
	}
}
