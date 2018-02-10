using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
}
