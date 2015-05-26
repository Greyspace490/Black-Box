using UnityEngine;
using System.Collections;

// General attack is a generic class used for attacks that don't have a more specific script.
// 
// 

public class GeneralAttack : Attack {

	public GeneralAttack(){ // GeneralAttack starts with no damage and is not a projectile.
		damage = 0;
		isProjectile = false;
		element = element.nothing;
	}

	public override void setDamage(int amount){ // Set damage of GeneralAttack
		damage = amount;
	}

	public override int getDamage(){ // Get the current damage of GeneralAttack
		return damage;
	}

	public override void Destroy(){ // Destroy this attack.
		Destroy(gameObject);
	}

	public override void Destroy(Vector3 pointOfImpact){ // Destroy this attack with awareness of coordinates.
		Destroy(gameObject);
	}

	public override void setProjectile(bool p){ // Set projectile status of GeneralAttack
		isProjectile = p;
	}

	public override void playSoundOnHit(){ // Play a sound when attack hits the target.
		AudioSource sfxPlayer = GameObject.FindWithTag ("SFX").GetComponent<AudioSource> ();
		sfxPlayer.clip = attackSound;
		sfxPlayer.Play();
	}

	public override element getElement(){
		return element;
	}
	
	public override void setElement(element newElement){
		element = newElement;
	}

	public override effectiveness getEffectiveness(){
		return effectiveness;
	}

	public override void setEffectiveness(effectiveness newEffectiveness){
		effectiveness = newEffectiveness;
	}
}
