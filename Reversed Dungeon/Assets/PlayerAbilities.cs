using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : Player {

	public void PlayerGainExp(){ //This one is constant, so should be in update. Should also just stand alone
		//outside of a void itself

		if (enemy gameObject == Enemy.isDead) { //This obviously aint done
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
		}
	}

	public void PlayerAttacks (int damage){

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
	}

	public void PlayerGenes(){

		if (Player.currentLevel == 2 || 4 || 6 || 8 || 10 || 12) {

			int value;
			Random geneLevel = value (1, 12);
			if (value == 1 || 5 || 9) {
				print ("Scaly Hide have been evolved");
				Player.currentHealth += 30;
				Player.currentArmor += 2;
			}
			if (value == 2 || 6 || 10) {
				print ("Claws have been evolved");
				Player.currentAttack += 10;
				Player.currentHealth += 10;
			}
			if (value == 3 || 7 || 11) {
				print ("Magic Aura have been evolved");
				Player.currentHealth += 20;
				Player.currentArmor += 2;
				Player.currentMana += 10;
			}
			if(value == 4 || 8 || 12) {
				print ("Shooting Spikes have been evolved");
				Player.currentAttack += 5;
				Player.currentArmor += 2;
			}
		}
	}

}
