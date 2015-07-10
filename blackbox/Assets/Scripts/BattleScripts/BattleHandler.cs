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
	public AIManager aiManager; // The AIManager, which controlls the enemy's attacks.
	public AudioSource musicSource; // The scene's main music player.
	public AudioClip victoryMusic; // Music that plays when the battle is won.
	public AudioClip failureMusic; // Music that plays when the battle is lost.
	public GameObject battleMessage; // Canvas that displays battle messages.  Used when the player dies.

	Save save; // The Save object that stores the location that the player came from to return them to after the fight as well as the AI used in the battle and the player and enemy animals used.
	bool waitForKeyRunning = false; // Indicates coroutine WaitForKey() is running.
	bool proceedBattle = false; // Indicates the battle has ended
	bool everythingPaused = false; // Makes sure that everything done at the end of the battle in the update routine only happens once. 
	Sprite background; // File location of the background of this battle.

	void Start(){ // Set up the battle field with all of the elements that are unique to this battle.

		save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
		background = save.getBattleBG();

		GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().sprite = background; // Load this scene's background.

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
	
	// This function is important; it not only handles the attack animation, but assigns damage and changes 
	//the UI HP counter.
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
			StartCoroutine(messageHandler.showMessage ("Attack was super effective!", 2));
		if (attack.getEffectiveness() == effectiveness.weak)
			StartCoroutine(messageHandler.showMessage ("Attack was ineffective!", 2));

		attack.playSoundOnHit(); // Play the attack's impact SFX
		
		Vector3 pointOfImpact = collider.transform.position; // Get the point of impact in case animations need to be applied once attack impacts.
		if (attack.isProjectile) // Checks to see if the attack should disappear after impact.
			attack.Destroy(pointOfImpact);

		StartCoroutine(animalGotHit(.15f, playerIsHit)); // Shakes and flashes hurt animal.
	}
	
	public void Update(){

		//
		//Handles what happens if either the player or enemy dies:

		// When the player dies
		if (player.getHPCurrent () < 1) {
			if (!everythingPaused){ // Pauses all fight actions, and turns off the ability for the player to use attacks.
				everythingPaused = true;

				PauseBattle (); // Pauses the player's timers.

				for (int i = 1; i <= 4; i++) // Pause all enemy actions.
					aiManager.GetComponentInChildren<AI>().pauseTimer(i, false);
							
				musicSource.clip = failureMusic;
				musicSource.Play();
			}

			if (battleMessage.activeInHierarchy == false) // Stops this from being summoned on top of itself infinitely.
				messageHandler.showPermanentMessage ("You've been defeated...");
			
			StartCoroutine(WaitForKey()); // Waits for the player to hit any key to proceed out of the battle.
			
			if (proceedBattle){
				save.setNewLocation (save.getPreviousLocation ()); // Loads the start screen
				Application.LoadLevel (2);
			}
		}

		// When the enemy dies
		if (enemy.getHPCurrent () < 1) {

			if (!everythingPaused){ // Pauses all fight actions, and turns off the ability for the player to use attacks.
				everythingPaused = true;

				PauseBattle (); // Pause all player actions.

				for (int i = 1; i <= 4; i++) // Pause all enemy actions.
					aiManager.GetComponentInChildren<AI>().pauseTimer(i, false);
	
				musicSource.clip = victoryMusic;
				musicSource.Play();

				Animal animal; // The animal that took the hit.
				animal = GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal>();
				StartCoroutine(animal.Dead()); // Fades animal away when defeated.
			}


			if (battleMessage.activeInHierarchy == false) // Stops message from playing on loop forever.
				messageHandler.showPermanentMessage ("Opponent defeated!");

			StartCoroutine(WaitForKey()); // Waits for the player to hit any key to proceed out of the battle.

			if (proceedBattle){
				save.setNewLocation (save.getPreviousLocation ()); // Loads the location the player came from.
				Application.LoadLevel (save.getPreviousLevel());
			}
		}
	}

	// The following pauses only the player's attack timers.
	public void PauseBattle(){ 
		Timer timer = (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>()) as Timer;
		UIHandler uih = GameObject.FindWithTag ("UIHandler").GetComponent<UIHandler> ();

		timer.pauseTimer (1, true);
		timer.pauseTimer (2, true);
		timer.pauseTimer (3, true);
		timer.pauseTimer (4, true);

		uih.toggleInteractableButton(1, false);
		uih.toggleInteractableButton(2, false);
		uih.toggleInteractableButton(3, false);
		uih.toggleInteractableButton(4, false);
	}

	public void UnPauseBattle(){
		Timer timer = (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>()) as Timer;
		UIHandler uih = GameObject.FindWithTag ("UIHandler").GetComponent<UIHandler> ();

		for (int i = 4; i > 0; i--) {
			switch (player.checkAttacks ()) {
			case 4:
				timer.pauseTimer (4, false);
				uih.toggleInteractableButton (4, true);
				goto case 3;
			case 3:
				timer.pauseTimer (3, false);
				uih.toggleInteractableButton (3, true);
				goto case 2;
			case 2:
				timer.pauseTimer (2, false);
				uih.toggleInteractableButton (2, true);
				goto case 1;
			case 1:
				timer.pauseTimer (1, false);
				uih.toggleInteractableButton (1, true);
				break;
			}
		}

	}

	// Waits for any key to be hit, then toggles the proceed battle boolean which ends the battle.
	IEnumerator WaitForKey(){
		yield return new WaitForSeconds (1.5f);

		if (!waitForKeyRunning) {
			waitForKeyRunning = true;
			Input.ResetInputAxes ();

			while (!Input.anyKeyDown) { // Waits for the player to press, then release, the space or enter button.
				yield return null;
			} 
			proceedBattle = true;
		}
	}
}
