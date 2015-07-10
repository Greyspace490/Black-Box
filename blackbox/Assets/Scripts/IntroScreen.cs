using UnityEngine;
using System.Collections;

// IntroScreen waits for any keypress, then proceeds to load the next level of the game.
//
//

public class IntroScreen : MonoBehaviour {

	bool go = false;
	
	void Update () {
		StartCoroutine (Pause (9));
		if (go)
			StartCoroutine(Proceed());
	}
	
	IEnumerator Proceed(){ // Fades to black.
		float fadeTime = GetComponent<Fade>().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(7);
	}
	
	IEnumerator Pause(int x){ // Pauses for x amount of seconds.
		yield return new WaitForSeconds(x);
		go = true;
	}
}