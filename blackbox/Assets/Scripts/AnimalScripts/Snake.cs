using UnityEngine;
using System.Collections;

public class Snake : Animal {
	
	public GameObject PlayerLocation; // The player object, used to determine where to instantiate scratch.
	public GameObject EnemyLocation; // The enemy object, used to determine where to instantiate scratch.
	public GameObject scratch;  // The scratch attack object that will be summoned when Snake attacks.
	public Animal snake_rockskin;
	BattleMessageHandler messageHandler;

	Snake(){
		animalName = "Snake";
		hpMax = 200;
		power = 25;
		defense = 15;
		speed = 80;	
		element = element.nothing;
		attackNames = new string[2] {"Attack", "Shed Skin"};
		speedModifiers = new float[2] {(float)Speed.normal, (float)Speed.vvslow};
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

		//
		// Change speed multipliers!!!!
		//
		//

		Enemy enemy = (GameObject.FindWithTag ("Enemy").GetComponent<Enemy> ()) as Enemy;
		Player player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		messageHandler = (GameObject.FindWithTag ("MessageHandler").GetComponent<BattleMessageHandler> ()) as BattleMessageHandler;

		messageHandler.StartCoroutine (messageHandler.showMessage ("Snake sheds its skin!", "It seems different..."));

		if (sentByPlayer) {

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
			if (enemy.getElement() == element.nothing){
				enemy.changeElement (element.stone);
			}else{
				enemy.changeElement(element.nothing);
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
			return Speed.vvslow;
		else
			return Speed.normal;
	}
}
