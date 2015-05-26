using UnityEngine;
using System.Collections;

//  The Player Object/Script holds and returns the particular variables associated with the equipped 
//  animal, including their stats, attacks, and sprite sheet. If a new animal is equipped, all these
//  stats and functions change.

public class Player : MonoBehaviour {
	
	public Animal myAnimal;
	public BattleHandler battleHandler;

	public int hpMax;
	public int power;
	public int defense;
	public int speed;
	public int hpCurrent;
	public string animalName;
	public element element;

	void Awake(){ //Sets Player states to that of the animal he/she is equipped with.

		hpMax = myAnimal.getHPMax();
		power = myAnimal.getPower();
		defense = myAnimal.getDefense();
		speed = myAnimal.getSpeed();
		hpCurrent = hpMax;
		animalName = myAnimal.getAnimalName();
		element = myAnimal.getElement ();
		//Add Weak against enum and strong against enum as collections and Evade
	}



	public void BasicAttack () // Standard attack
	{

		myAnimal.Attack (power, true);
	
		//The following resets the player's timer after the attack commences.
		var timerObject = GameObject.FindWithTag ("Timer").GetComponent<Timer>();
		timerObject.ResetTimer (1);
	}

	public void Attack2 () // Standard attack
	{
		myAnimal.Attack2 (power, true);

		//The following resets the player's timer after the attack commences.
		var timerObject = GameObject.FindWithTag ("Timer").GetComponent<Timer>();
		timerObject.ResetTimer (2);
	}

	public void Attack3 () // Standard attack
	{
		myAnimal.Attack3 (power, true);

		//The following resets the player's timer after the attack commences.
		var timerObject = GameObject.FindWithTag ("Timer").GetComponent<Timer>();
		timerObject.ResetTimer (3);
	}

	public void Attack4 () // Standard attack
	{
		myAnimal.Attack4 (power, true);

		//The following resets the player's timer after the attack commences.
		var timerObject = GameObject.FindWithTag ("Timer").GetComponent<Timer>();
		timerObject.ResetTimer (4);
	}

	public string getAttackNames (int i){ // Direct method that accesses the player's animal's attack names for naming the attack GUI buttons.
		return myAnimal.getAttackName (i);
	}

	public float getAttackSpeedMultiplier (int i){ // Direct method that gets the player's animal's different attack speeds for modifying timer speeds in the timer class.
		return myAnimal.getAttackSpeedMultiplier (i);
	}

	public int checkButtons(){ // Checks to see how many attacks the equipped animal has to place buttons.
		return myAnimal.numberOfAttacks ();
	}

	public void placeAnimal() // Places the sprite of whatever animal is currently equipped in the location of the Player
	{
		Animal player = Instantiate (myAnimal, new Vector3 (-6.5f, 0, 0), Quaternion.identity) as Animal;

		player.tag = "PlayerAnimal";
		player.transform.parent = this.transform; //Parents the animal to this object.

	}

	public int getHPMax() {
		return hpMax;
	}

	public int getHPCurrent()
	{
		return hpCurrent;
	}

	public void alterHP(int num)
	{
		hpCurrent = hpCurrent + num;
	}
	
	public int getPower(){
		return power;
	}
	
	public int getDefense(){
		return defense;
	}
	
	public int getSpeed(){
		return speed;
	}
	
	public string getAnimalName(){
		return animalName;
	}

	public element getElement(){
		return element;
	}

	public element changeElement(element newElement){
		return element = newElement;
	}
}
