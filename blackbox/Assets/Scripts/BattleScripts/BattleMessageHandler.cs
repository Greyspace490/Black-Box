using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

// BattleMessageHandler is used to manage messages that are sent to the UI, including damage done to
// the player and enemy.
// 

public class BattleMessageHandler : MonoBehaviour {

	public Text playerDamage; // Text used to display damage done to player
	public Text enemyDamage; // Text used to display damage done to enemy
	public Text message;

	void Awake()
	{
		playerDamage.enabled = false; // Hide message damage
		enemyDamage.enabled = false;
		message.enabled = false;
	}

	public BattleMessageHandler()
	{
	}
	
	public IEnumerator showDamage(int damage, bool hurtsPlayer) // Displays damage done to opponents.
	{
		if (hurtsPlayer) { // If damage is done to the player, display the following.
			playerDamage.enabled = true;
			playerDamage.text = Convert.ToString (damage);
		} 
		else // If damage is done to the enemy, display the following.
		{
			enemyDamage.enabled = true;
			enemyDamage.text = Convert.ToString (damage);
		}

		yield return new WaitForSeconds (36 * Time.deltaTime); // Time message is displayed for.
		resetDamage ();

	}

	// showMessage displays messages to the battlefield, including whether an attack was effective or not.
	public IEnumerator showMessage(string newMessage) 
	{
		message.text = newMessage;
		message.enabled = true;
		yield return new WaitForSeconds (66 * Time.deltaTime); // Time message is displayed for.
		resetMessage ();
	}

	public IEnumerator showMessage(string newMessage, string newMessage2) // Shows longer messages.
	{
		message.text = newMessage;
		message.enabled = true;
		yield return new WaitForSeconds (66 * Time.deltaTime); // Time message is displayed for.
		yield return new WaitForSeconds (20 * Time.deltaTime);
		message.text = newMessage2;
		yield return new WaitForSeconds (66 * Time.deltaTime);
		resetMessage ();
	}
	
	void resetMessage(){
		message.enabled = false;
	}

	void resetDamage() // Reset damage counters to be hidden
	{
		playerDamage.enabled = false;
		enemyDamage.enabled = false;
	}
}
