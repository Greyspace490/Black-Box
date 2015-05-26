using UnityEngine;
using System.Collections;

//  EnemyAI functions both as the enemy's timer, and as their "AI," allowing the enemy to attack.  In the future, or depending on the enemy,
//  this will also be where the enemy decides which attack to use or decides on a strategy.
// 

public class EnemyAI : MonoBehaviour {

	float enemyTimer; // The current time, which accumulates until it reaches "full"
	int enemyTimerEnd; // The time at which the enemy is capable of attack.

	void Start(){
		enemyTimerEnd = 80 + UnityEngine.Random.Range(0,45); // The random element is added so that the enemy does not always attack at exactly the same interval.
		enemyTimer = 0;
	}

	void Update () { // The timer counts up to the enemyTimerEnd, and then the enemy attacks.

		enemyTimer = enemyTimer + (10 * Time.deltaTime); // Adds to time.

		if (enemyTimer > enemyTimerEnd){
			var enemy = GameObject.FindWithTag ("Enemy").GetComponent<Enemy>();
	
			enemy.BasicAttack(); // Enemy attacks.
	
			enemyTimer = 0; // Resets timer.
			enemyTimerEnd = 80 + UnityEngine.Random.Range(0,45);	// Adds a random amount of time to enemyTimer, to randomize interval between attacks.
			
		}
	}
}


////////////////////////////////////
/*   TEST OUT THE ENEMY HP       //
		var enemy2 = GameObject.FindWithTag ("Enemy").GetComponent<Enemy>();
		Debug.Log (enemy2.getHPCurrent().ToString());
		*/