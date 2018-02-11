using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

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
	public float startMP; //MP = Movement Points
	public float currentMP; //MP = Movement Points, change this over the course of the game
	public float startAP; //AP = Attack Points
	public float currentAP; //AP = Attack Points, change this over the course of the game

	//Variables required for leveling the player
	public int newLevelExp = 100;
	public int currentExp = 0; 
	public int startLevel = 1;
	public int currentLevel;
	public int killExp = (15 + (Enemy.Levels * 1.5));
	public int score;

	//Turn
	public int turn;

	//Attacks
	bool melee = true;
	bool ranged = false;
	bool spell = false;

	//Deadsies
	bool PlayerisDead = false;

	// Use this for initialization
	void Start () {

		//Sets up the class with health, mana, attack, armor, movement points and attack points in the beinning
		currentAttack = startAttack;
		currentArmor = startArmor;
		currentHealth = startHealth;
		currentMana = startMana;
		currentMP = startMP;
		currentAP = startAP;
	}

	// Update is called once per frame
	void Update () {

		score = Player.currentExp;

	}

	public void playerLevelUp(){
		newLevelExp *= 1.5;
		Player.currentHealth  =+ 20;
		Player.currentMana =+ 5;
		Player.currentAttack =+ 5;
		Player.currentAP += 0.5f;
		Player.currentMP += 0.5f;
		PlayerAbilities.PlayerGenes ();

		EnemyAbilities.enemyLevelUp ();
	}
}