using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Stats of a character
	public int startHealth; //Starting Health
	public int currentHealth; //Current Health, change this over the course of the game
	public int startMana; //Starting Mana
	public int currentMana; //Current Mana, change this over the course of the game
	public int startArmor; //Starting Armor
	public int currentArmor; //Current Armor, change this over the course of the game
	public int startAttack; //Starting damage
	public int currentAttack; //Current damage, change this over the course of the game

	//Action Points
	public int startMP; //MP = Movement Points
	public int currentMP; //MP = Movement Points, change this over the course of the game
	public int startAP; //AP = Attack Points
	public int currentAP; //AP = Attack Points, change this over the course of the game

	//Turn
	public int turn;

	//Attacks
	bool melee = true;
	bool ranged = false;
	bool spell = false;

	//Deadsies
	bool isDead = false;
	bool takeDamage = false;

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

	public void toggleAttacks (int attack){

		attack = currentAttack;

		//These 3 specifies which attack you want toggled
		if(Input.GetKeyDown("1")){ 
			print("Melee attack is now toggled");
			attack = currentAttack;
			melee = true;
			ranged = false;
			spell = false;
		}
		if(Input.GetKeyDown("2")){
			print("Ranged attack is now toggled");
			attack =* (currentAttack * 0.75);
			melee = false;
			ranged = true;
			spell = false;
		}
		if(Input.GetKeyDown("3")){
			print("Spell is now toggled");
			attack = (currentAttack * 1.50);
			melee = false;
			ranged = false;
			spell = true;
		}
		if (Input.GetMouseButtonDown ("0" || "1" || "2")) {
			print (BattleFlow.enemies[] + " has been targeted");
			//tags the enemy with left, right, middle mouse click.
		}
		if (Input.GetKeyDown ("enter")) {
			print ("Turn Ending");
			turn++; // 
		}
		//What happens when attacking
		if(Input.GetKeyDown("space")){
			print("I stab at thee");
			if(melee = true){

				currentAP = -1;
			}
			if(ranged = true){

				currentAP = -1;
			}
			if(spell = true){

				currentAP = -1;
			}
		}
	}
}
