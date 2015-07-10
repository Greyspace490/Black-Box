using UnityEngine;
using System.Collections;

// LightningBoltAttack is a projectile attack that leaves behind sparks after it makes contact.
// 
//

public class LightningBoltAttack : Attack {

	public GameObject particleEffects; // Particle effects to be left after attack strikes its target.
	float wave = .1f; // Changes the size of the wave that the lightning moves in.

	public LightningBoltAttack(){ // Sets attack as a projectile.
		damage = 0;
		isProjectile = true;
		element = element.electricity;
	}
	
	public override void setDamage(int amount){ // Sets damage that Lightning will do.
		damage = amount;
	}
	
	public override int getDamage(){ // Returns damage that Lightning will do.
		return damage;
	}
	
	public override void Destroy() { // Not recommended, as the particles will not be instantiated at the right point.
		Instantiate(particleEffects, Vector3.zero, Quaternion.identity );
		Destroy(gameObject);
	}

public override void Destroy(Vector3 pointOfImpact) { // Destroys the Lightning, and creates a spark effect using particle effects at the point of impact.
		Instantiate(particleEffects, pointOfImpact, Quaternion.identity );
		Destroy(gameObject);
	}
	
	public override void setProjectile(bool p){ // Changes projectile state of lightning.
		isProjectile = p;
	}
	
	public override void playSoundOnHit() { // Plays lightning sound effect.
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

	void FixedUpdate(){

			// Moves the lightning up and down like a wave.
			wave = (Mathf.Sin(6f *Time.time)) * .05f;
			transform.position = transform.position + new Vector3 (0, wave, 0);

	}
}
