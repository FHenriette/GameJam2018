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

	//Turn
	public int turn;

	//Attacks
	public bool melee = true;
	public bool ranged = false;
	public bool spell = false;

	//Deadsies
	public bool isDead = false;

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

		PlayerGainExp ();
		/*
		public void takeDamage(int damage){

			currentHealth =- (damage - currentArmor);

		}

		if(currentHealth <= 0 && !isDead){
			Death();
		}

		public void Death(){

		isDead = true;

		playerMovement = false;
		playerMelee = false;
		playerRanged = false;
	*/
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

	public void PlayerAttacks (int damage){
		/*
		damage = Player.currentAttack;

		//These 3 specifies which attack you want toggled
		if (Input.GetKeyDown ("1")) { 
			print ("Melee attack is now toggled");
			damage = Player.currentAttack;
			Player.melee = true;
			Player.ranged = false;
			Player.spell = false;
		}
		if (Input.GetKeyDown ("2")) {
			print ("Ranged attack is now toggled");
			damage = *0.75;
			melee = false;
			ranged = true;
			spell = false;
		}
		if (Input.GetKeyDown ("3")) {
			print ("Spell is now toggled");
			damage = *1.50f;
			melee = false;
			ranged = false;
			spell = true;
		}
		if (Input.GetMouseButtonDown ("0" || "1" || "2")) {
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
	*/}

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
		}
	}
}