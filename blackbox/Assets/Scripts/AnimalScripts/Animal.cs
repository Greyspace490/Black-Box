using UnityEngine;
using System.Collections;

//  Animal is an abstract class that stores the stats of each animal as well
//  as their attacks.
//  

public abstract class Animal : MonoBehaviour {

	protected int hpMax; // Animal's maximum amount of life.
	protected int power; // Animal's attack power.
	protected int defense; // Animal's defense rating.
	protected int speed; // This rating is used to determine how fast the animal's timer fills.
	protected string animalName ; // The animal's name.
	protected element element; // The element, if any, that the animal represents.
	protected string[] attackNames;// An array with all attack names listed.
	protected float[] speedModifiers; // An array with the speed modifiers for each attack listed.
	protected Color actualColor; // The color of the animal sprite, to be used in fading the animal if it dies.

	// Attack power is based on the power of the parent, which may be higher than the animal. Returns 
	// damageResults, which is a struct that keeps the damage done by an attack as well as whether the
	// attack was effective.
	abstract public damageResults Attack(int parentPower, bool sentByPlayer); // Standard attack held by all animals.

	//float value;


	virtual public damageResults Attack2(int parentPower, bool sentByPlayer){ // Secondary attack, if applicable.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}
	virtual public damageResults Attack3(int parentPower, bool sentByPlayer){ // Third attack, if applicable.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}
	virtual public damageResults Attack4(int parentPower, bool sentByPlayer){ // Fourth attack, if applicable.
		damageResults noResults = new damageResults(0, effectiveness.weak);
		return noResults;
	}

	public virtual string getAttackName(int i){ // Gets attack names. If the animal only has one attack, that button is usually called Attack, so this method returns that.
		return "Attack";
	}

	public virtual float getAttackSpeedMultiplier (int i){ // The first attack usually fills the timer at the Animal's Speed stat. Other attacks have modifiers that this method returns using the static method Constants of vvvslow, vvslow, vslow, slow, normal, fast, vfast, vvfast, and fastvvvast.
		return Speed.normal;
	}

	public virtual int numberOfAttacks()
	{
		return 1;
	}

	public virtual int getHPMax(){
		return hpMax;
	}
	
	public virtual int getPower(){
			return power;
	}
	
	public virtual int getDefense(){
		return defense;
	}
	
	public virtual int getSpeed(){
		return speed;
	}
	
	public virtual string getAnimalName(){
		return animalName;
	}

	public virtual element getElement(){
		return element;
	}

	// When an animal dies, it fades out of existence.
	public virtual IEnumerator Dead(){ 
		for (float f = 1f; f >= 0; f -= 0.008f) { // f -= controls the speed of the fade
			actualColor = GetComponent<SpriteRenderer> ().color;
			actualColor.a = f;
			GetComponent<SpriteRenderer> ().color = actualColor;
			yield return null;
		}
	}

	// Flash is used to flash the animal that is attacking just before the attack is initialized.
	public virtual IEnumerator Flash(){ 
		Color white; // Pure white.
		Color original; // Original color of animal sprite.
		actualColor = GetComponent<SpriteRenderer> ().color; // Color of the animal.

		original = actualColor;

		white.r = 255; // Color to flash to (Red)
		white.b = 0;
		white.g = 0;
		white.a = 255;
	
		for (float f = 1f; f >= 0; f -= 0.5f) { // f -= controls the speed of the fade
			yield return new WaitForSeconds(.01f);
			GetComponent<SpriteRenderer> ().color = white;
			yield return new WaitForSeconds(.02f);
			GetComponent<SpriteRenderer> ().color = original;
			yield return new WaitForSeconds(.01f);
		}
	}
}
