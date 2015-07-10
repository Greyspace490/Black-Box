using UnityEngine;
using System.Collections;

// AI functions both as the enemy's timer, and as their "AI," allowing the enemy to attack.  Depending 
// on the enemy, this is also be where the enemy decides which attack to use or decides on a strategy,
// and where events happen such as dialogues.

public class AI : MonoBehaviour {

	protected float enemyTime; // The current time, which accumulates until it reaches "full"
	protected float enemyTime2;
	protected float enemyTime3;
	protected float enemyTime4;
	protected int enemyTimerMax; // The time at which the enemy is capable of attack.
	protected bool enemyTimerOn; // Stops the timer from increasing.
	protected bool enemyTimerOn2;
	protected bool enemyTimerOn3;
	protected bool enemyTimerOn4;
	protected Enemy enemy; // The enemy, which is used to get speed statistics.
	protected bool pauseEnemyTimer; // Pauses or unpauses enemy timers.
	protected bool pauseEnemyTimer2;
	protected bool pauseEnemyTimer3;
	protected bool pauseEnemyTimer4;

	// AttackPause waits for a certain amount of seconds then attacks using the assigned
	// attack number.
	virtual public IEnumerator AttackPause(int attackNumber, int time)	{
		if (attackNumber == 1) {
			enemyTimerOn = false; // Stops the timer from continuing to count during the pause.
			enemyTime = 0;
		}
		if (attackNumber == 2) {
			enemyTimerOn2 = false;
			enemyTime2 = 0;
		}
		if (attackNumber == 3) {
			enemyTimerOn3 = false;
			enemyTime3 = 0;
		}
		if (attackNumber == 4) {
			enemyTimerOn4 = false;
			enemyTime4 = 0;
		}
		
		yield return new WaitForSeconds (time); // Time before the attack is executed.
		
		if (attackNumber == 1) {
			enemy.BasicAttack(); // Actually attack
			enemyTimerOn = true;  // Turn the timer back on.
		}
		if (attackNumber == 2) {
			enemy.Attack2();
			enemyTimerOn2 = true;
		}
		if (attackNumber == 3) {
			enemy.Attack3();
			enemyTimerOn3 = true;
		}
		if (attackNumber == 4) {
			enemy.Attack4();
			enemyTimerOn4 = true;
		}
	}

	virtual public void pauseTimer(int timerNumber, bool onOrOff){ // Turns on or off a timer 
		switch (timerNumber) {
		case 1:
			pauseEnemyTimer = !onOrOff;
			break;
		case 2:
			pauseEnemyTimer2 = !onOrOff;
			break;
		case 3:
			pauseEnemyTimer3 = !onOrOff;
			break;
		case 4:
			pauseEnemyTimer4 = !onOrOff;
			break;
		}
	}
}
