using UnityEngine;
using System.Collections;

//  BattleHandlerPC detects if attacks that have been sent out have contacted where the player is located.
//  If so, it checks who sent the attack, and sends that information to battleHandler.
//  

public class BattleHandlerPC : MonoBehaviour {

	public BattleHandler battleHandler;

	public void OnTriggerEnter2D(Collider2D collider) // Detects if attacks have "made contact." 
	{
		if (collider.tag == "SentByEnemy") // Makes sure that the projectile is from the opponent.
		{
			
			battleHandler.attackReceived(collider, true); // Attack makes contact with Opponent. Bool: True = player received attack, False = enemy received attack.
			
		}
	}
}
