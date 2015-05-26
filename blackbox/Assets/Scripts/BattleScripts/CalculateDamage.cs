using UnityEngine;
using System.Collections;

// CalculateDamage is a static script that can be summoned any time damage must be calculated.  It uses
// the formula damage = (power - defense) * resistance.
//
// Standard returns a damageResults type, which is a struct class that carries two peices of information.
// The first is the damage dealt, and the second is whether the attack was effective or not.  Future
// versions might include other information such as status effects like poison.

public static class CalculateDamage{

	public static damageResults Standard(int power, element element, bool sentByPlayer){ // 

		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

		int enemyDefense = enemy.getDefense ();
		int playerDefense = player.getDefense ();

		int damage; // Total damage that this attack will inflict.
		float multiplier; // The multiplier applied to damage based on elemental resistance.
		effectiveness effectiveness; // How effective this attack is against the opponent. Used to calculate multiplier.

		effectiveness = getResistance (element, sentByPlayer); // Check effectiveness of this attack against opponent.
		if (effectiveness == effectiveness.regular) {
			multiplier = 1f;
		} else if (effectiveness == effectiveness.strong) {
			multiplier = 1.5f;
		} else {
			multiplier = .5f;
		}

		if (enemyDefense < 0) // Make sure that a negative defense does not add to the damage score.
			enemyDefense = 0;
		if (playerDefense < 0)
			playerDefense = 0;

		if (sentByPlayer) {
			damage = (int)((power - enemy.getDefense())* multiplier); 
		} else {
			damage = (int)((power - player.getDefense())* multiplier); 
		}

		if (damage < 0) // Make sure that the attack does not heal the opponent.
			damage = 0;

		damageResults results = new damageResults ();
		results.damage = (damage * -1);
		results.effectiveness = effectiveness;

		return (results);
	}

	// Effectiveness takes the element of the sending attack, and whether or not the attack is sent by 
	// a player. It then determines the element of the opponent, and compares the elements to determine
	// whether the first element is weak against the second, strong against it, or issues normal damage.
	// Power is as follows: Electricity>Water>Fire>Ice>Stone>Electricty.  Regular is not strong or weak
	// against anything.
	public static effectiveness getResistance(element firstElement, bool sentByPlayer){ 

		element secondElement;
		effectiveness result;

		if (sentByPlayer){ // If the attack being calculated was sent by the player, then the second element it is compared to must be taken from the enemy.
			Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			secondElement = enemy.getElement();
		}else { // If the attack being calculated was sent by the enemy, then the second element it is compared to must be taken from the player.
			Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			secondElement = player.getElement();
		}

		int e1 = (int)firstElement;
		int e2 = (int)secondElement;

		switch (e1)
		{
		case 0:
			if (e2 == 1)
				result = effectiveness.strong;
			else if (e2 == 4)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 1:
			if (e2 == 2)
				result = effectiveness.strong;
			else if (e2 == 0)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 2:
			if (e2 == 3)
				result = effectiveness.strong;
			else if (e2 == 1)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 3:
			if (e2 == 4)
				result = effectiveness.strong;
			else if (e2 == 2)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 4:
			if (e2 == 0)
				result = effectiveness.strong;
			else if (e2 == 3)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 5:
			result = effectiveness.regular;
			break;   
		default:
			result = effectiveness.regular;
			break;
		}

		return result;
	}

	// This is the same as the above method, except it calculates whether two elements are strong, weak,
	// or regular against each other and does not look at the opponent at all.
	public static effectiveness getResistance(element firstElement, element secondElement){ 

		effectiveness result;

		int e1 = (int)firstElement;
		int e2 = (int)secondElement;
		
		switch (e1)
		{
		case 0:
			if (e2 == 1)
				result = effectiveness.strong;
			else if (e2 == 4)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 1:
			if (e2 == 2)
				result = effectiveness.strong;
			else if (e2 == 0)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 2:
			if (e2 == 3)
				result = effectiveness.strong;
			else if (e2 == 1)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 3:
			if (e2 == 4)
				result = effectiveness.strong;
			else if (e2 == 2)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 4:
			if (e2 == 0)
				result = effectiveness.strong;
			else if (e2 == 3)
				result = effectiveness.weak;
			else
				result = effectiveness.regular;
			break;
		case 5:
			result = effectiveness.regular;
			break;   
		default:
			result = effectiveness.regular;
			break;
		}
		
		return result;
	}

}


