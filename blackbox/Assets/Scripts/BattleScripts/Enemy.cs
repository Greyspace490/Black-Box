using UnityEngine;
using System.Collections;

//  The Enemy Object/Script holds and returns the particular variables associated with the equipped 
//  animal, including their stats, attacks, and sprite sheet. If a new animal is equipped, all these
//  stats and functions change.

public class Enemy : MonoBehaviour {

	public Animal enemyAnimal;
	public BattleHandler battleHandler;
		
	public int hpMax;
	public int power;
	public int defense;
	public int speed;
	public int hpCurrent;
	public string animalName;
	public element element;
	
	void Awake(){ //Sets Enemy states to that of the animal he/she is equipped with.

		hpMax = enemyAnimal.getHPMax();
		power = enemyAnimal.getPower();
		defense = enemyAnimal.getDefense();
		speed = enemyAnimal.getSpeed();
		hpCurrent = hpMax;
		animalName = enemyAnimal.getAnimalName();
		element = enemyAnimal.getElement ();
		//Add Weak against enum and strong against enum as collections and Evade
	}

	public void BasicAttack () // Standard attack
	{
		enemyAnimal.Attack (power, false);
	}

	public void placeAnimal() // Places the sprite of whatever animal is currently equipped in the location of the Enemy
	{

		Animal enemy = Instantiate (enemyAnimal, new Vector3 (7, 0, 0), Quaternion.Euler(0, 0, 0)) as Animal;
		enemy.transform.localScale += new Vector3(-2, 0, 0); 

		// The following unparents the multiple animal followers so they are unaffected by attacks.
		Transform enemyKids = enemy.GetComponent<Transform> ().GetChild (1);
		enemyKids.tag = "EnemyKids";
		enemyKids.transform.parent = this.transform;

		enemy.tag = "EnemyAnimal";
		enemy.transform.parent = this.transform; //Parents the animal to this object.
				
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