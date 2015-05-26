using UnityEngine;
using System.Collections;

// Attack objects carry not only the animations of an attack, but also store damage information in the form
// of this script. This allows UI updates to occur only after the opponent is actually hit. Attacks also 
// store their own sounds.

public abstract class Attack : MonoBehaviour {
	
	public int damage; // The actual amount of damage this particular attack ended up doing.
	public bool isProjectile; // Is this attack a projectile?
	public AudioClip attackSound; // Attack's sound effect.
	public AudioSource sfxPlayer; // Attack's sound source.
	protected element element; // Kind of element the attack represents, if any;
	protected effectiveness effectiveness; // Store of whether the attack was effective or not.
	
	abstract public void setDamage (int amount); // Allows attacker to set damage to communicate with other functions.
	abstract public int getDamage(); // Allows a function to determine what damage the attack dealt.
	abstract public void Destroy(Vector3 pointOfImpact); // Destroy's the attack. Uses Vector3 in case point of impact is important.
	abstract public void Destroy(); // Destroys the attack with no concern for point of impact.
	abstract public void setProjectile(bool p); // Changes projectile status.  May be unnecessary.
	abstract public void playSoundOnHit(); // Plays the attack's sound.
	abstract public element getElement(); // Returns the kind of element this attack uses.
	abstract public void setElement(element newElement); // Sets the kind of element this attack will use.
	abstract public effectiveness getEffectiveness(); // Gets the effectiveness that the attack had.
	abstract public void setEffectiveness(effectiveness effectiveness); // Sets the effectiveness that the attack had.
	
}
