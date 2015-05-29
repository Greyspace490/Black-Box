using UnityEngine;
using System.Collections;

// TitleScreen waits for any keypress, then proceeds to load the Intro level of the game.
//
//

public class TitleScreen : MonoBehaviour {

	bool acceptKeyPress = false;

	void Update () {
		if (!acceptKeyPress){ // Makes sure that a few seconds have passed before the player can proceed.
			StartCoroutine (Pause (3));
		}

		if (Input.anyKey && acceptKeyPress == true) { // Calls the StartGame() function, which fades the screen to black.
			StartCoroutine(StartGame());
		}

	}

	IEnumerator StartGame(){ // Fades to black.
		float fadeTime = GetComponent<Fade>().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(4);
	}

	IEnumerator Pause(int x){ // Pauses for x amount of seconds.
		yield return new WaitForSeconds(x);
		acceptKeyPress = true;
	}
}
