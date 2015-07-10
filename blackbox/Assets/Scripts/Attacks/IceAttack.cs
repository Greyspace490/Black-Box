using UnityEngine;
using System.Collections;

public class IceAttack : Attack {

	public GameObject particleEffects; // Particle effects to be left after attack strikes its target.

	public IceAttack(){ // Sets attack as a projectile.
		damage = 0;
		isProjectile = true;
		element = element.ice;
	}

	public override void setDamage(int amount){ // Sets damage that Ice will do.
		damage = amount;
	}
	
	public override int getDamage(){ // Returns damage that Ice will do.
		return damage;
	}
	
	public override void Destroy() { // Destroys the Ice.
		Destroy(gameObject);
	} 
	
	public override void Destroy(Vector3 pointOfImpact) { // Destroys the Ice and knows where collision took place.
		Instantiate(particleEffects, pointOfImpact, Quaternion.identity );
		Destroy(gameObject);
	}
	
	public override void setProjectile(bool p){ // Changes projectile state of Ice.
		isProjectile = p;
	}
	
	public override void playSoundOnHit() { // Plays Ice sound effect.
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
