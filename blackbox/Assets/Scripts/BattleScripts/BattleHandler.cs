using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//  The BattleHandler Object/Script handles battle actions, such as detecting when an opponent is dead,
//  applying damage animations to animals that take damage, and sending damage information to the 
//  MessageHandler.

public class BattleHandler : MonoBehaviour {

	public BattleMessageHandler messageHandler;
	public Player player;
	public Enemy enemy;
	public Text menuHPCurrent;

	void Start(){ // Set up the battle field with all of the elements that are unique to this battle.

		menuHPCurrent.text = System.Convert.ToString(player.getHPMax()) + " / " + player.getHPMax(); //Set the UI to the player's current HP and max HP

		player.placeAnimal(); // Initialize sprites of animals
		enemy.placeAnimal ();
	}
	
	public IEnumerator animalGotHit(float amount, bool isPlayer) // If an animal takes damage, it is knocked backwards and a flashing animation is applied.
	{
		GameObject animal; // The animal that took the hit.
		SpriteRenderer flasher; // Turned on and off to make sprite flash when hit.
		Vector3 originalSpot; // Location where animal took hit to return it to after it is knocked backwards.

		float i = 0; // The amount of loops to do knockback/flash

		if (isPlayer == true) { //If the player has the animal that was hit, associate with that sprite.

			animal = GameObject.FindWithTag ("PlayerAnimal");
			flasher = GameObject.FindWithTag ("PlayerAnimal").GetComponent<SpriteRenderer> ();
			originalSpot = animal.transform.position;
		} 
		else { //If the enemy has the animal that was hit, associate with that sprite.

			animal = GameObject.FindWithTag ("EnemyAnimal");
			flasher = GameObject.FindWithTag ("EnemyAnimal").GetComponent<SpriteRenderer> ();
			originalSpot = animal.transform.position;
		}
		
		while(i < amount) { // Start flashing and knockback loop.
		
			animal.transform.Translate(-.06f, Random.Range(-.08f,.08f), 0f); // Shakes animal and sends back.
			
			//Flashes the animal to show that it is being damaged.
			if(flasher.enabled == true)	{
				flasher.enabled = false;
			}else if (flasher.enabled == false){
				flasher.enabled = true;}

			yield return null; //Slows down the animations and effects so that movement and flashing doesn't happen instantly.
			i = i + (1*Time.deltaTime);
		}

		// Reset the animal to original state.
		animal.transform.position = originalSpot;
		flasher.enabled = true;
		
	}
	
	// This function is important; it not only handles the attack animation, but assigns damage and changes the UI HP counter.

	public void attackReceived(Collider2D collider, bool playerIsHit) // When an Attack collides with an animal, the damage that attack inflicts must be sent to the MessageHandler, and the attack must potentially be destroyed.
	{
		GameObject newAttack = collider.gameObject; // The collider is whatever attack hit the animal.
		Attack attack = newAttack.GetComponent<Attack> ();

		if (playerIsHit) { // If the player is hit, send to MessageHandler, alter the player's HP, and change HP UI element.
			StartCoroutine (messageHandler.showDamage (attack.getDamage (), true));

			player.alterHP (attack.getDamage ()); // Remove amount of HP from player.
			menuHPCurrent.text = System.Convert.ToString (player.getHPCurrent ()) + " / " + player.getHPMax();
		} else { // If the enemy is hit, send to MessageHandler and alter their HP.

			StartCoroutine (messageHandler.showDamage (attack.getDamage (), false));
	
			enemy.alterHP(attack.getDamage()); // Remove amount of HP from enemy.
		}

		// Send notification to MessageHandler concerning effectiveness of attack.
		if (attack.getEffectiveness() == effectiveness.strong)
			StartCoroutine(messageHandler.showMessage ("Attack was super effective!"));
		if (attack.getEffectiveness() == effectiveness.weak)
			StartCoroutine(messageHandler.showMessage ("Attack was ineffective!"));

		attack.playSoundOnHit(); // Play the attack's impact SFX
		
		Vector3 pointOfImpact = collider.transform.position; // Get the point of impact in case animations need to be applied once attack impacts.
		if (attack.isProjectile) // Checks to see if the attack should disappear after impact.
			attack.Destroy(pointOfImpact);

		StartCoroutine(animalGotHit(.15f, playerIsHit)); // Shakes and flashes hurt animal.
	}

	public void Update(){

		//Handles what happens if either the player or enemy dies:
			//Player
		if (player.getHPCurrent() < 1)
			Application.LoadLevel (1);
			//Enemy
		if (enemy.getHPCurrent() < 1)
			Application.LoadLevel (2);
	}



}
