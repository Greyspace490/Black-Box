using UnityEngine;
using System.Collections;

//  The Enemy Object/Script holds and returns the particular variables associated with the equipped 
//  animal, including their stats, attacks, and sprite sheet. If a new animal is equipped, all these
//  stats and functions change.

public class Enemy : MonoBehaviour {

	public BattleHandler battleHandler;
	public int hpCurrent;
	public int hpMax;
	public int power;
	public int defense;
	public int speed;
	public string animalName;
	public element element;

	Animal enemyAnimal;
	Save save;
	
	void Awake(){ //Sets Enemy states to that of the animal he/she is equipped with.

		// The following retreives the animal stored in Save.
		save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
		enemyAnimal = save.getEnemyAnimal ();

		hpMax = enemyAnimal.getHPMax();
		power = enemyAnimal.getPower();
		defense = enemyAnimal.getDefense();
		speed = enemyAnimal.getSpeed();
		hpCurrent = hpMax;
		animalName = enemyAnimal.getAnimalName();
		element = enemyAnimal.getElement ();
		//Add Weak against enum and strong against enum as collections and Evade
	}

	public void BasicAttack (){ // Standard attack

		StartCoroutine (PauseBasicAttack());
	}

	public IEnumerator PauseBasicAttack(){
		Animal currentAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
		
		currentAnimal.StartCoroutine(currentAnimal.Flash());
		
		yield return new WaitForSeconds (.5f);
		
		enemyAnimal.Attack (power, false);
	}

	public void Attack2 (){ // Second attack

		StartCoroutine (PauseAttack2());

	}

	public IEnumerator PauseAttack2(){
		Animal currentAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
		
		currentAnimal.StartCoroutine(currentAnimal.Flash());
		
		yield return new WaitForSeconds (.5f);
		
		enemyAnimal.Attack2 (power, false);
	}
	
	public void Attack3 () // Third attack
	{
		StartCoroutine (PauseAttack3());
	
	}

	public IEnumerator PauseAttack3(){
		Animal currentAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
		
		currentAnimal.StartCoroutine(currentAnimal.Flash());
		
		yield return new WaitForSeconds (.5f);
		
		enemyAnimal.Attack3 (power, false);
	}
	
	public void Attack4 () // Fourth attack
	{
		StartCoroutine (PauseAttack4());

	}

	public IEnumerator PauseAttack4(){
		Animal currentAnimal = (GameObject.FindWithTag ("EnemyAnimal").GetComponent<Animal> ()) as Animal;
		
		currentAnimal.StartCoroutine(currentAnimal.Flash());
		
		yield return new WaitForSeconds (.5f);
		
		enemyAnimal.Attack4 (power, false);
	}

	public int checkAttacks(){ // Checks to see how many attacks the equipped animal has to place buttons.
		return enemyAnimal.numberOfAttacks ();
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

	public float getAttackSpeedMultiplier (int i){ // Direct method that gets the player's animal's different attack speeds for modifying timer speeds in the timer class.
		return enemyAnimal.getAttackSpeedMultiplier (i);
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