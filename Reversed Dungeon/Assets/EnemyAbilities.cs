using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : Enemy {

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

	}
}