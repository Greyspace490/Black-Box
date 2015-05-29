using UnityEngine;
using System.Collections;

// IntroScreen waits for any keypress, then proceeds to load the next level of the game.
//
//

public class IntroScreen : MonoBehaviour {

	bool acceptKeyPress = false;
	
	void Update () {
		if (!acceptKeyPress){ // Makes sure that a few seconds have passed before the player can proceed.
			StartCoroutine (Pause (10));
		}
		
		if (Input.anyKey && acceptKeyPress == true) { // Calls the StartGame() function, which fades the screen to black.
			StartCoroutine(Proceed());
		}
		
	}
	
	IEnumerator Proceed(){ // Fades to black.
		float fadeTime = GetComponent<Fade>().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(5);
	}
	
	IEnumerator Pause(int x){ // Pauses for x amount of seconds.
		yield return new WaitForSeconds(x);
		acceptKeyPress = true;
	}
}