using UnityEngine;
using System.Collections;

//  BattleHandlerEC detects if attacks that have been sent out have contacted where the enemy is located.
//  If so, it checks who sent the attack, and sends that information to battleHandler.
//  

public class BattleHandlerEC : MonoBehaviour {

	public BattleHandler battleHandler;

	public void OnTriggerEnter2D(Collider2D collider) // Detects if attacks have "made contact."  
	{
		
		if (collider.tag == "SentByPlayer") { // Makes sure that the projectile is from the opponent.
			
			battleHandler.attackReceived(collider, false); // Attack makes contact with Opponent. Bool: True = player received attack, False = enemy received attack.
			
		}
		
		
	}
}
