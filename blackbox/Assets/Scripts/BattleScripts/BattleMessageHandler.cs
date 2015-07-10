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
	public GameObject messageCanvas; // Main canvas for displaying text messages.
	public Text messageText; // Text of messageCanvas.
	public GameObject DialogueCanvas; // Canvas for displaying dialogues.
	public Text dialogueMessageText; // Text used to display dialogue.
	public GameObject face; // Portrait for use with dialogue canvas.

	void Awake()
	{
		playerDamage.enabled = false; // Hide message damage
		enemyDamage.enabled = false;
		messageCanvas.SetActive(false);
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

	public IEnumerator showDialogue(string newMessage, string portrait, int timeAm){ // Displays dialogue messages.
		dialogueMessageText.text = newMessage;
		DialogueCanvas.SetActive(true);
		face.GetComponent<Image>().sprite  = Resources.Load<Sprite>(portrait);
		yield return new WaitForSeconds (timeAm); // Time message is displayed for.
		resetDialogue ();
	}

	public void showDialogue(string newMessage, string portrait){ // Displays dialogue messages without a time limit.
		dialogueMessageText.text = newMessage;
		DialogueCanvas.SetActive(true);
		face.GetComponent<Image>().sprite  = Resources.Load<Sprite>(portrait);
	}

	// showMessage displays messages to the battlefield, including whether an attack was effective or not.
	public IEnumerator showMessage(string newMessage, int timeAm) 
	{
		messageText.text = newMessage;
		messageCanvas.SetActive(true);
		yield return new WaitForSeconds (timeAm); // Time message is displayed for.
		resetMessage ();
	}

	// showMessage displays a permanent message to the battlefield (used for victory information.
	public void showPermanentMessage(string newMessage) 
	{
		messageText.text = newMessage;
		messageCanvas.SetActive(true);
	}

	public IEnumerator showMessage(string newMessage, string newMessage2, int timeAm, int timeAm2) // Shows longer messages.
	{
		// First message
		messageText.text = newMessage; 
		messageCanvas.SetActive(true);
		yield return new WaitForSeconds (timeAm); // Time message is displayed for.

		// Second message
		messageCanvas.SetActive(true); // Sets the message as active again in case this message was interupted by a different message.
		messageCanvas.GetComponentInChildren<Text>().text = newMessage2;
		yield return new WaitForSeconds (timeAm2);

		resetMessage ();
	}
	
	void resetMessage(){
		messageCanvas.SetActive(false);
	}

	void resetDamage() // Reset damage counters to be hidden
	{
		playerDamage.enabled = false;
		enemyDamage.enabled = false;
	}

	void resetDialogue() // Reset dialogue.
	{
		DialogueCanvas.SetActive(false);
	}
}
