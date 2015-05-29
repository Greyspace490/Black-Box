using UnityEngine;
using System.Collections;

public class Sheep : Animal {
	
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate lightningbolt.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate lightningbolt.
	public GameObject lightningbolt; // The lightningbolt attack object that will be summoned when Sheep attacks.
	public AudioClip swish;
	BattleMessageHandler messageHandler;

	Sheep(){
		animalName = "Sheep";
		hpMax = 100;
		power = 25;
		defense = 10;
		speed = 120;
		element = element.electricity;
		attackNames = new string[3] {"Attack", "Herd Sight", "Breed"};
		speedModifiers = new float[3] {(float)Speed.normal, (float)Speed.vvfast, (float)Speed.vvslow};
	}

	public override damageResults Attack(int parentPower, bool sentByPlayer)
	{
		AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
		sfxPlayer.clip = swish;
		sfxPlayer.Play ();

		damageResults damageResults = new damageResults ();

		if (sentByPlayer == false) { // The enemy is doing this attack.
			GameObject projectileLightning = Instantiate (lightningbolt, EnemyLocation.transform.position, Quaternion.Euler (0, 180, 0)) as GameObject;
			Attack projLight = projectileLightning.GetComponent<Attack>();

			damageResults = CalculateDamage.Standard(parentPower, projLight.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			projLight.setDamage(damageResults.damage); // Sets damage of Lightning 
			projLight.setEffectiveness(damageResults.effectiveness); // Sets whether Lightning was effective or not.

			projectileLightning.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0); // Sends the lightning left.
			projectileLightning.tag = "SentByEnemy"; // Sets the tag of the attack so that only the correct collider registers contact with it.

			return (damageResults);
		}else { //The player is doing this attack.
			GameObject projectileLightning = Instantiate (lightningbolt, PlayerLocation.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			projectileLightning.transform.localScale += new Vector3(-2, 0, 0); 
			Attack projLight = projectileLightning.GetComponent<Attack>(); 

			damageResults = CalculateDamage.Standard(parentPower, projLight.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			projLight.setDamage(damageResults.damage); // Sets damage of Lightning 
			projLight.setEffectiveness(damageResults.effectiveness); // Sets whether Lightning was effective or not.

			projectileLightning.GetComponent<Rigidbody2D>().velocity = new Vector3(10, 0, 0); // Sends the lightning right.
			projectileLightning.tag = "SentByPlayer"; // Sets the tag of the attack so that only the correct collider registers contact with it.

			return (damageResults);
		}
	}

	// Sheep's examine class allows player to see enemy weakness, and an estimation of their health.
	public override damageResults Attack2(int parentPower, bool sentByPlayer){ 
		Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		if (sentByPlayer) {
			messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

			element eElement = enemy.getElement ();
			string message;

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
			messageHandler.StartCoroutine (messageHandler.showMessage ((enemy.animalName + message), (enemy.animalName + message2)));
		}else{ // The enemy gains no advantage, so it just shows the player that they've been looked at.
				messageHandler.StartCoroutine (messageHandler.showMessage (enemy.animalName + "looks at you!"));
			}

		// Since no attack is instantiated, these results are never received by MessageHandler.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	public override damageResults Attack3(int parentPower, bool sentByPlayer){ 
		Debug.Log ("Breed");
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	public override int numberOfAttacks()
	{
		return 3;
	}

	public override string getAttackName(int i){
		if (i == 3)
			return "Breed";
		if (i == 2)
			return "Herd Sight";
		else
			return "Attack";
	}

	public override float getAttackSpeedMultiplier (int i){
		if (i == 3)
			return Speed.vvslow;
		if (i == 2)
			return Speed.vvfast;
		else
			return Speed.normal;
	}
}

