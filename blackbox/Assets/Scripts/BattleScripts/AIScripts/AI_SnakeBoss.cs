using UnityEngine;
using System.Collections;

// AI_SnakeBoss is a special single-scripted event that plays a number of dialogues during the boss battle of the overworld.
// 
//

public class AI_SnakeBoss : AI {
	
	double eventTimer; // Timer used to allow events to happen.
	BattleMessageHandler messageHandler; // Handles dialogues.
	BattleHandler battleHandler;

	void Start(){

		enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;
		battleHandler = (GameObject.FindWithTag ("BattleHandler").GetComponent<BattleHandler> ()) as BattleHandler;


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

		eventTimer = 0;

		// Checks how many attacks the enemy has, and only turns on timers for those attacks.
		switch (enemy.checkAttacks ()) {
		case 4:
			enemyTimerOn4 = true;
			goto case 3;
		case 3:
			enemyTimerOn3 = true;
			goto case 2;
		case 2:
			enemyTimerOn2 = true;
			goto case 1;
		case 1:
			enemyTimerOn = true;
			break;
		}
	}

	bool trigger1 = false;
	bool trigger2 = false; 
	bool trigger3 = false; 
	bool trigger4 = false; 
	bool trigger5 = false; 
	bool trigger6 = false; 
	bool trigger7 = false; 
	bool trigger8 = false; 
	bool trigger9 = false; 
	bool trigger10 = false; 
	bool trigger11 = false; 
	bool pauseEnemy = false;
	bool trigger12 = false; 


	void Update () { // The timer counts up to the enemyTimerMax, and then the enemy attacks.

		eventTimer = eventTimer + (1 * Time.deltaTime);

		if (eventTimer > 13 && !trigger1) {
			trigger1 = true;
			StartCoroutine(AttackPause(2, UnityEngine.Random.Range(0,6)));	
		}
		if (eventTimer > 22 && !trigger2) {
			trigger2 = true;
			StartCoroutine(messageHandler.showDialogue("These rock snakes have matured and have a hard rock shell. Electricity doesn't harm them!", Portrait.Calvert, 5));
		}

		if (eventTimer > 31 && !trigger3) {
			trigger3 = true;
			battleHandler.PauseBattle();
			pauseEnemy = true;
			StartCoroutine(messageHandler.showDialogue("No wonder that Simab guy was afraid of these snakes.  They're invincible.", Portrait.Kayla, 7));
		}
		if (eventTimer > 41 && !trigger4) {
			trigger4 = true;
			messageHandler.showDialogue("Not invincible. They're cold-blooded. The stone makes them lose heat even faster.", Portrait.Calvert);
		}
		if (eventTimer > 48 && !trigger5) {
			trigger5 = true;
			messageHandler.showDialogue("So an ice attack would work well?", Portrait.Quinn);
		}
		if (eventTimer > 55 && !trigger6) {
			trigger6 = true;
			messageHandler.showDialogue("Yeah.  And sometimes an electrisheep even gives birth to a icesheep...", Portrait.Calvert);
		}
		if (eventTimer > 62 && !trigger7) {
			trigger7 = true;
			messageHandler.showDialogue("But that almost never happens. And that hardly helps us now.", Portrait.Calvert);
		}
		if (eventTimer > 69 && !trigger8) {
			trigger8 = true;
			messageHandler.showDialogue("Kayla, he must be referring to a recessive allele that leads to a icesheep phenotype!", Portrait.Quinn);
		}
		if (eventTimer > 76 && !trigger9) {
			trigger9 = true;
			messageHandler.showDialogue("A time storm approaches. Your amulet protects us and we can use that to our advantage.", Portrait.Quinn);
		}
		if (eventTimer > 83 && !trigger10) {
			trigger10 = true;
			messageHandler.showDialogue("Use the Hardy–Weinberg principle. Arrange the population to yield icesheep.", Portrait.Quinn);
		}
		if (eventTimer > 90 && !trigger11) {
			trigger11 = true;
			StartCoroutine(messageHandler.showDialogue("Yeah! Breed an icesheep, and use it to defeat the snakes in our way!", Portrait.Calvert,6));
		}
		if (eventTimer > 97 && !trigger12) {
			trigger12 = true;
			battleHandler.UnPauseBattle();
			pauseEnemy = false;
		}




		// The following adds time to each timer only if the timers have attacks attached to them.
		// Each attack is affected by the attack speed of each individual attack the enemy has.
		if (enemyTimerOn && !pauseEnemyTimer && !pauseEnemy){ 
			enemyTime = enemyTime + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(1)); 
		}
		if (enemyTimerOn2 && !pauseEnemyTimer2){
			enemyTime2 = enemyTime2 + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier(2)); 
		}

		// If the enemy's timer fills, the attack is executed via AttackPause, which is used to create
		// a randomly assigned time interval, which makes the enemy's attacks less consistant, as if they
		// are considering their attack.
		if (enemyTime > enemyTimerMax){
			StartCoroutine(AttackPause(1, UnityEngine.Random.Range(0,10)));
		}
	}
}




////////////////////////////////////
/*   TEST OUT THE ENEMY HP       //
		var enemy2 = GameObject.FindWithTag ("Enemy").GetComponent<Enemy>();
		Debug.Log (enemy2.getHPCurrent().ToString());
		*/