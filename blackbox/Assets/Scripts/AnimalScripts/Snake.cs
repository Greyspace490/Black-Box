using UnityEngine;
using System.Collections;

public class Snake : Animal {
	
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate scratch.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate scratch.
	public GameObject scratch;  // The scratch attack object that will be summoned when Snake attacks.
	public AudioClip shedSkinSound; // The sound that the snake makes when shedding skin.
	BattleMessageHandler messageHandler;

	Snake(){
		animalName = "Snake";
		hpMax = 40;
		power = 25;
		defense = 15;
		speed = 80;	
		element = element.nothing;
		attackNames = new string[2] {"Attack", "Shed Skin"};
		speedModifiers = new float[2] {(float)Speed.normal, (float)Speed.slow};
	}
	
	public override damageResults Attack(int parentPower, bool sentByPlayer){	 
		
		damageResults damageResults = new damageResults ();
		
		if (sentByPlayer == false) { // The enemy is doing this attack.
			GameObject scr = Instantiate (scratch, PlayerLocation.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
			Attack scratchAttack = scr.GetComponent<Attack>();
			
			damageResults = CalculateDamage.Standard(parentPower, scratchAttack.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			scratchAttack.setDamage(damageResults.damage); // Sets damage of Scratch.
			scratchAttack.setEffectiveness(damageResults.effectiveness); // Sets whether Scratch was effective or not.
			
	
			scr.tag = "SentByEnemy"; // Sets the tag of the attack so that only the correct collider registers contact with it.
			
			return (damageResults);
		}else { //The player is doing this attack.
			GameObject scr = Instantiate (scratch, EnemyLocation.transform.position, Quaternion.identity) as GameObject;
			Attack scratchAttack = scr.GetComponent<Attack>(); 
			
			damageResults = CalculateDamage.Standard(parentPower, scratchAttack.getElement(), sentByPlayer); // Gets a package that contains damage and effectiveness level of attack.
			scratchAttack.setDamage(damageResults.damage); // Sets damage of Lightning 
			scratchAttack.setEffectiveness(damageResults.effectiveness); // Sets whether Lightning was effective or not.

			scr.tag = "SentByPlayer"; // Sets the tag of the attack so that only the correct collider registers contact with it.
			
			return (damageResults);
		}
	}

	public override damageResults Attack2(int parentPower, bool sentByPlayer){

		Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

		if (sentByPlayer) {

			messageHandler.StartCoroutine (messageHandler.showMessage ("Snake sheds its skin!", "It seems different...", 2, 3));
			
			AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
			sfxPlayer.clip = shedSkinSound;
			sfxPlayer.Play();

			Animal oldAnimal = (GameObject.FindWithTag ("PlayerAnimal").GetComponent<Animal> ()) as Animal;
			Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator>()) as Animator;

			if (player.getElement() == element.nothing){
				player.changeElement (element.stone);
				changeAnimation.SetTrigger("Shed");
			}else{
				player.changeElement(element.nothing);
				changeAnimation.SetTrigger("Shed");
			}


		} else {// If the enemy used attack

			Animal oldAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
			Animator changeAnimation = (oldAnimal.GetComponentInChildren<Animator>()) as Animator;

			if (enemy.getElement() == element.nothing){
				messageHandler.StartCoroutine (messageHandler.showMessage ("Snake sheds its skin!", "It seems different...", 2, 3));
				
				AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
				sfxPlayer.clip = shedSkinSound;
				sfxPlayer.Play();

				enemy.changeElement (element.stone);
				changeAnimation.SetTrigger("Shed");
			}else{
				messageHandler.StartCoroutine (messageHandler.showMessage ("Snake sheds its skin!", "It seems different...", 2, 3));
					
				AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
				sfxPlayer.clip = shedSkinSound;
				sfxPlayer.Play();

				enemy.changeElement(element.nothing);
				changeAnimation.SetTrigger("Shed");
			}
		}

		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	public override int numberOfAttacks()
	{
		return 2;
	}
	
	public override string getAttackName(int i){
		if (i == 2)
			return "Shed Skin";
		else
			return "Attack";
	}
	
	public override float getAttackSpeedMultiplier (int i){
		if (i == 2)
			return Speed.slow;
		else
			return Speed.normal;
	}
}
