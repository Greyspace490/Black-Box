using UnityEngine;
using System.Collections;

// The confused AI is used mostly for testing, but represents an enemy that executes no attacks.
// 
//

public class AI_Confused : AI {

	BattleMessageHandler mh;

	void Start(){
		enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		mh = (GameObject.FindGameObjectWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

		enemyTimerMax = (200 - enemy.getSpeed()); // Set the general speed of all attacks based on the enemy's speed.
		enemyTime = 0;
		enemyTimerOn = true;
	}

	void Update () { // The timer counts up to the enemyTimerMax, and then the enemy attacks.
		if (!pauseEnemyTimer) {
			enemyTime = enemyTime + ((10 * Time.deltaTime) * enemy.getAttackSpeedMultiplier (1)); 
		}

		if (enemyTime > enemyTimerMax){
			StartCoroutine(mh.showMessage(enemy.getAnimalName() + " looks confused...", 2));
			enemyTime = 0;
		}
	}
}


////////////////////////////////////
/*   TEST OUT THE ENEMY HP       //
		var enemy2 = GameObject.FindWithTag ("Enemy").GetComponent<Enemy>();
		Debug.Log (enemy2.getHPCurrent().ToString());
		*/