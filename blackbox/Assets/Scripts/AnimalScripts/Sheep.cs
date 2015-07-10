using UnityEngine;
using System.Collections;

public class Sheep : Animal {
	
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate lightningbolt.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate lightningbolt.
	public GameObject lightningbolt; // The lightningbolt attack object that will be summoned when Sheep attacks.
	public GameObject ice; // The ice attack object that will be summoned when Sheep attacks.
	public GameObject blink; // The animation played when the animal views the other.
	public AudioClip swish;
	public AudioClip ding;
	BattleMessageHandler messageHandler;
	GameObject sheepAttack; // Attack1's attack animation/object.
	public GameObject mainQuiz; // The main quiz canvas, for use with Attack 3.
	public GameObject quiz1; // Individual quizes
	public GameObject quiz2;
	public GameObject quiz3;
	public GameObject quiz4;
	public GameObject quiz5;
	public GameObject quiz6;

	Sheep(){
		animalName = "Sheep";
		hpMax = 220;
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
			messageHandler.StartCoroutine (messageHandler.showMessage ((enemy.animalName + message), (enemy.animalName + message2), 2, 2));
		
			//The enemy Sent this attack
		}else{ // The enemy gains no advantage, so it just shows the player that they've been looked at.
			sfxPlayer.Play ();

			Instantiate (blink, (EnemyLocation.transform.position + new Vector3 (-.90f, +.23f, 0)), Quaternion.Euler (0, 180, 0));	
			messageHandler.StartCoroutine (messageHandler.showMessage (enemy.animalName + " looks at you!", 2));
		}

		// Since no attack is instantiated, these results are never received by MessageHandler.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	//
	//
	// Instantiates an instance of the Hardy-Weinberg quiz, randomly selected.
	public override damageResults Attack3(int parentPower, bool sentByPlayer){ 

		Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

		if (sentByPlayer) { // Player is attacking.

			GameObject q = Instantiate (mainQuiz) as GameObject;

			System.Random rnd = new System.Random();
			int quizNum = rnd.Next(1, 7);

			// The following randomly chooses from available quizes.
			switch (quizNum){
			case 1:
				q.transform.GetChild(0).gameObject.SetActive(true); // Quiz 1
				break;
			case 2:
				q.transform.GetChild(1).gameObject.SetActive(true); // Quiz 2
				break;
			case 3:
				q.transform.GetChild(2).gameObject.SetActive(true); // Quiz 3
				break;
			case 4:
				q.transform.GetChild(3).gameObject.SetActive(true); // Quiz 4
				break;
			case 5:
				q.transform.GetChild(4).gameObject.SetActive(true); // Quiz 5
				break;
			case 6:
				q.transform.GetChild(5).gameObject.SetActive(true); // Quiz 6
				break;
			}
		} else { // Enemy is attacking.
			Animal oldAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
			Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator> ()) as Animator;
			
			if (enemy.getElement () == element.electricity) {
				enemy.changeElement (element.ice);
				changeAnimation.SetTrigger ("Breed");
				messageHandler.StartCoroutine (messageHandler.showMessage ("Sheep evolves!", 3));
			} else {
				// If the enemy is already electricity, there is little reason to change back and it should
				// probably not, most of the time.
	
				enemy.changeElement (element.electricity);
				changeAnimation.SetTrigger ("Breed");
				messageHandler.StartCoroutine (messageHandler.showMessage ("Sheep evolves!", 3));

			}
		}

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

