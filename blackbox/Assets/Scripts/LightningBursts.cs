using UnityEngine;
using System.Collections;

// LightningBursts show and hide lightning at random rates determined by frequency.
//
//

public class LightningBursts : MonoBehaviour {

	public int frequency; // How often the lightning strikes.
	public float seconds; // For how long the lightning shows when it appears.

	float time; // Timer
	
	void Update () {
		time= time + (1f * Time.deltaTime);

		if ((Random.Range (0, 201) > frequency) && time < 6){ // Frequency determines how often lightning strikes.  time < 6 refers to the time when lightning should stop striking due to the event coming to a close.
			StartCoroutine(Strike ());
			if (!GetComponent<AudioSource>().isPlaying) // Stops lightning from unnaturally muting itself.
				GetComponent<AudioSource>().Play();
		}

	
	}

	IEnumerator Strike(){ // Actually renders the lightning to the screen 
		GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(seconds);
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
