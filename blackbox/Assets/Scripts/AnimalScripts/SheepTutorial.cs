using UnityEngine;
using System.Collections;

// SheepTutorial is a special version of the sheep animal used to get the player used to fighting.  It is the same as
// the sheep, except doesn't have its third "Breed" attack.
//

public class SheepTutorial : Animal {
	
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate lightningbolt.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate lightningbolt.
	public GameObject lightningbolt; // The lightningbolt attack object that will be summoned when Sheep attacks.
	public GameObject ice; // The ice attack object that will be summoned when Sheep attacks.
	public GameObject blink; // The animation played when the animal views the other.
	public AudioClip swish; // Sound for Attack 1
	public AudioClip ding; // Sound for Attack 2
	BattleMessageHandler messageHandler;
	GameObject sheepAttack; // Attack1's attack animation/object.
	
	SheepTutorial(){
		animalName = "Sheep";
		hpMax = 220;
		power = 25;
		defense = 10;
		speed = 120;
		element = element.electricity;
		attackNames = new string[2] {"Attack", "Herd Sight"};
		speedModifiers = new float[2] {(float)Speed.normal, (float)Speed.vvfast};
	}

	public override damageResults Attack(int parentPower, bool sentByPlayer)
	{
		AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
		sfxPlayer.clip = swish;
		sfxPlayer.Play ();

		damageResults damageResults = new damageResults ();

		if (sentByPlayer == false) { // The enemy is doing this attack.
		
			Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;

			if (enemy.getElement() == element.electricity)
				sheepAttack = Instantiate (lightningbolt, EnemyLocation.transform.position, Quaternion.Euler (0, 180, 0)) as GameObject;
			else // The attack is an ice attack.
				sheepAttack = Instantiate (ice, EnemyLocation.transform.position, Quaternion.Euler (0, 180, 0)) as GameObject;

			Attack sAttack = sheepAttack.GetComponent<Attack>();

			damageResults = CalculateDamage.Standard(parentPower, sAttack.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			sAttack.setDamage(damageResults.damage); // Sets damage of Attack
			sAttack.setEffectiveness(damageResults.effectiveness); // Sets whether Attack was effective or not.

			sheepAttack.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0); // Sends the lightning left.
			sheepAttack.tag = "SentByEnemy"; // Sets the tag of the attack so that only the correct collider registers contact with it.

			return (damageResults);
		}else { //The player is doing this attack.

			Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
			
			if (player.getElement() == element.electricity){
				sheepAttack = Instantiate (lightningbolt, PlayerLocation.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
				sheepAttack.transform.localScale += new Vector3(-3, 0, 0); 
			}
			else{ // The attack is an ice attack.
				sheepAttack = Instantiate (ice, PlayerLocation.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
				sheepAttack.transform.localScale += new Vector3(-5.4f, 0, 0); 
			}

			Attack sAttack = sheepAttack.GetComponent<Attack>(); 

			damageResults = CalculateDamage.Standard(parentPower, sAttack.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			sAttack.setDamage(damageResults.damage); // Sets damage of Lightning 
			sAttack.setEffectiveness(damageResults.effectiveness); // Sets whether Lightning was effective or not.

			sheepAttack.GetComponent<Rigidbody2D>().velocity = new Vector3(10, 0, 0); // Sends the lightning right.
			sheepAttack.tag = "SentByPlayer"; // Sets the tag of the attack so that only the correct collider registers contact with it.

			return (damageResults);
		}
	}

	//
	//
	// Sheep's examine method allows player to see enemy weakness, and an estimation of their health.
	public override damageResults Attack2(int parentPower, bool sentByPlayer){ 
		Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;

		AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
		sfxPlayer.clip = ding;

		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

		if (sentByPlayer) { // Player used this attack.

			sfxPlayer.Play ();

			element eElement = enemy.getElement ();
			string message;

			Instantiate (blink, (PlayerLocation.transform.position + new Vector3 (.73f, .33f, 0)), Quaternion.Euler (0, 0, 0));

			switch ((int)eElement) { // Takes the enemy's element, and returns what that element is weak against.
			case 0:
				message = " is weak against stone!";
				break;
			case 1:
				message = " is weak against electricity!";
				break;
			case 2:
				message = " is weak against water!!";
				break;
			case 3:
				message = " is weak against fire!";
				break;
			case 4:
				message = " is weak against ice!";
				break;
			default:
				message = " isn't weak against anything!";
				break;
			}

			string message2;
			float ratio = (((float)enemy.getHPCurrent()/ (float)enemy.getHPMax())*100f);

			if (ratio > 75){
				message2 = " looks fine.";
			}else if (ratio > 50){
				message2 = " looks slightly damaged.";
			}else if(ratio > 25){
				message2 = " looks pretty bad.";
			}else {
				message2 = " looks practically gone.";
			}


			// Display's message.
			messageHandler.StartCoroutine (messageHandler.showMessage ((enemy.animalName + message), (enemy.animalName + message2), 2, 3));
		
			//The enemy Sent this attack
		}else{ // The enemy gains no advantage, so it just shows the player that they've been looked at.

			// This attack happens rapidly and to no true effect, so the enemy should rarely use it
			sfxPlayer.Play ();

			Instantiate (blink, (EnemyLocation.transform.position + new Vector3 (-.90f, +.23f, 0)), Quaternion.Euler (0, 180, 0));	
				messageHandler.StartCoroutine (messageHandler.showMessage (enemy.animalName + " looks at you!", 2));
		}

		// Since no attack is instantiated, these results are never received by MessageHandler.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	
	public override int numberOfAttacks()
	{
		return 2;
	}

	public override string getAttackName(int i){
		if (i == 2)
			return "Herd Sight";
		else
			return "Attack";
	}

	public override float getAttackSpeedMultiplier (int i){
		if (i == 2)
			return Speed.vvfast;
		else
			return Speed.normal;
	}
}

