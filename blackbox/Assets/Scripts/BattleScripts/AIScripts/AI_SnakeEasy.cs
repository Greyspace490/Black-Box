﻿using UnityEngine;
using System.Collections;

// The  AI for an "easy" snake chooses only the first snake attack, and does not transform the snake to its
// resistant rock form.
//

public class AI_SnakeEasy : AI {

	void Start(){
		enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;

		enemyTimerMax = (200 - enemy.getSpeed()); // Set the general speed of all attacks based on the enemy's speed.
		enemyTime = 0;
		enemyTime2 = 0;
		enemyTime3 = 0;
		enemyTime4 = 0;
		enemyTimerOn = false;
		enemyTimerOn2 = false;
		enemyTimerOn3 = false;
		enemyTimerOn4 = false;
		pauseEnemyTimer = false;
		pauseEnemyTimer2 = false;
		pauseEnemyTimer3 = false;
		pauseEnemyTimer4 = false;

		// Checks how many attacks the enemy has, and only turns on timers for those attacks.
		switch (enemy.checkAttacks ()) {
		case 4:
			enemyTimerOn4 = true;
			goto case 3;
		case 3:
			enemyTimerOn3 = true;
			goto case 2;
		case 2:
			goto case 1;
		case 1:
			enemyTimerOn = true;
			break;
		}
	}

	void Update () { // The timer counts up to the enemyTimerMax, and then the enemy attacks.

		// The following adds time to each timer only if the timers have attacks attached to them.
		// Each attack is affected by the attack speed of each individual attack the enemy has.
		if (enemyTimerOn && !pauseEnemyTimer){ 
			enemyTime = enemyTime + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(1)); 
		}
		if (enemyTimerOn2 && !pauseEnemyTimer2){
			enemyTime2 = enemyTime2 + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(2)); 
		}
		if (enemyTimerOn3 && !pauseEnemyTimer3){
			enemyTime3 = enemyTime3 + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(3));
		}
		if (enemyTimerOn4 && !pauseEnemyTimer4){
			enemyTime4 = enemyTime4 + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(4)); 
		}

		// If the enemy's timer fills, the attack is executed via AttackPause, which is used to create
		// a randomly assigned time interval, which makes the enemy's attacks less consistant, as if they
		// are considering their attack.
		if (enemyTime > enemyTimerMax){
			StartCoroutine(AttackPause(1, UnityEngine.Random.Range(0,10)));
		}
		if (enemyTime2 > enemyTimerMax){
			StartCoroutine(AttackPause(2, UnityEngine.Random.Range(0,6)));	
		}
		if (enemyTime3 > enemyTimerMax){
			StartCoroutine(AttackPause(3, UnityEngine.Random.Range(0,6)));
		}
		if (enemyTime4 > enemyTimerMax){
			StartCoroutine(AttackPause(4, UnityEngine.Random.Range(0,6)));			
		}
	}
}




////////////////////////////////////
/*   TEST OUT THE ENEMY HP       //
		var enemy2 = GameObject.FindWithTag ("Enemy").GetComponent<Enemy>();
		Debug.Log (enemy2.getHPCurrent().ToString());
		*/