using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterStats {

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

	//Turn
	public int turn;

	//Attacks
	bool melee = true;
	bool ranged = false;
	bool spell = false;

	//Deadsies
	bool isDead = false;

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
		PlayerDeath ();

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

	public void takeDamage(){

		Player.currentHealth =- (Enemy.currentAttack - Player.currentArmor);

	}

	public void PlayerDeath(){

		if(Player.currentHealth <= 0 && !PlayerisDead){
			PlayerisDead = true;

			//playerMovement = false;
			//playerMelee = false;
			//playerRanged = false;
			//save score
			//stop the game
			//display score on a screen
		}
	}
}