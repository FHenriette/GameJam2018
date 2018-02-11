using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterStats {

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

		EnemyAbilities.setEnemyLevel ();
		EnemyAbilities.EnemyDeath ();
		/*
		public void takeDamage(int damage){

			currentHealth =- (damage - currentArmor);

		}
*/
	}

	//When next movement is a player, then player is in range, if not player will not be in range. duurh
	public void onTriggerEnter(){

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

}
