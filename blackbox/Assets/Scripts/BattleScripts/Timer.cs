using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

//  The Timer keeps track of the Player's ability to select attacks, activates buttons to allow attack, and updates 
//  a timer UI element to show the amount of time left before the Player can attack again.
//  

public class Timer : MonoBehaviour {
	
	public AudioClip timerSound;
	//since this is the audiosource attached to this object, i can probably make this private and prefer to it directly.
	public AudioSource sfxPlayer;
	public RawImage timerRaw; // The timer object (bar) to be filled as the timer fills.
	public RawImage timerRaw2;
	public RawImage timerRaw3;
	public RawImage timerRaw4;
	public RawImage blackBar; // The black bar beneath the timer object which shows how much more of the bar needs to be filled.
	public RawImage blackBar2;
	public RawImage blackBar3;
	public RawImage blackBar4;
	public Material black; // Color of blackBar.
	public Material green; // Color of filling timerRaw.
	public Material white; // Color of filled timerRaw.
	float time; // The current time, which accumulates until it reaches "full"
	float time2;
	float time3;
	float time4;
	bool timerOn; // Stops the timer from increasing.
	bool timerOn2;
	bool timerOn3;
	bool timerOn4;
	bool toggle; // Sets the sound to play only once, and allows the rect to register a white texture when timer fills up.
	bool toggle2;
	bool toggle3;
	bool toggle4;
	int timerMax; // What float time must reach before the timer is considered full.
	Player player; // Access to the player, so that their Speed stat can be accessed for the timer.
	UIHandler uiHandler; // Access to UIHandler to toggle button properties.
	Camera cam; // The main camera, which is used to set the Rect coordinates relative to the camera so that timers resize relative to window size regardless of whether the game is aspect ratio or not.
	bool pause; // Toggle used to turn on and off the timer without hiding it.
	bool pause2;
	bool pause3;
	bool pause4;
	// The following are used in the equation for moving the timer the right distance to make it appear to fill from
	// left to right instead of from the middle outwards on both sides.  newAmount corresponds to the amount of increase
	// in the timerbar, old amount is the amount of the bar filled previously, maxDistanceMoved is the distance that 
	// the timer must be moved when its time is set to zero.
	Vector2 newAmount; 
	Vector2 newAmount2;
	Vector2 newAmount3;
	Vector2 newAmount4;
	Vector2 oldAmount;
	Vector2 oldAmount2;
	Vector2 oldAmount3;
	Vector2 oldAmount4;
	Vector2 maxDistanceMoved;
	Vector2 maxDistanceMoved2;
	Vector2 maxDistanceMoved3;
	Vector2 maxDistanceMoved4;
	
	void Start (){

		player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		uiHandler = (GameObject.FindWithTag ("UIHandler").GetComponent<UIHandler> ()) as UIHandler;

		timerMax = (200 - player.getSpeed()); // Sets the timer to align with the player's speed.

		// Set the blackBars' size so that they are equal to the timer's max size.
		blackBar.rectTransform.sizeDelta = new Vector2 ((timerMax * 21.25f), 170f);
		blackBar2.rectTransform.sizeDelta = new Vector2 ((timerMax * 21.25f), 170f);
		blackBar3.rectTransform.sizeDelta = new Vector2 ((timerMax * 21.25f), 170f);
		blackBar4.rectTransform.sizeDelta = new Vector2 ((timerMax * 21.25f), 170f);

		// Reposition the blackBar so it sits under the timerBar.
		blackBar.rectTransform.localPosition = new Vector3 ((-285.5f + (blackBar.rectTransform.sizeDelta.x /2)), -184f, 2);
		blackBar2.rectTransform.localPosition = new Vector3 ((-285.5f + (blackBar.rectTransform.sizeDelta.x /2)), -951f, 2);
		blackBar3.rectTransform.localPosition = new Vector3 ((-285.5f + (blackBar.rectTransform.sizeDelta.x /2)), -1686f, 2);
		blackBar4.rectTransform.localPosition = new Vector3 ((-285.5f + (blackBar.rectTransform.sizeDelta.x /2)), -2452f, 2);


		//Defaults time for each bar at 0.
		time = 0; 
		time2 = 0;
		time3 = 0;
		time4 = 0;
		
		// Sound toggles.
		toggle = true;
		toggle2 = true;
		toggle3 = true;
		toggle4 = true;
		
		//  Turns on/off the display of timers according to whether the player's animal has attacks for those timers.
		timerOn = false;
		timerOn2 = false;
		timerOn3 = false;
		timerOn4 = false;
		
		// Turns on/off the increase of time of displayed timers.
		pause = true;
		pause2 = true;
		pause3 = true;
		pause4 = true;
		
		switch (player.checkAttacks()) {
		case 4:
			timerOn4 = true;
			pause4 = false;
			goto case 3;
		case 3:
			timerOn3 = true;
			pause3 = false;
			goto case 2;
		case 2:
			timerOn2 = true;
			pause2 = false;
			goto case 1;
		case 1:
			timerOn = true;
			pause = false;
			break;
		}
	}
	public float offsset=1;
	void Update () // Here, the timer is filled.
	{
		// Update speed changes in player's stats.
		// Note: Right now, changes, especially big ones, affect the size of the timer on the screen.  Need to fix this.
		timerMax = (200 - player.getSpeed()); 

		// The following all deals with the ticking of the timer and the player's ability to attack.
		maxDistanceMoved = new Vector2 (-285.5f, -184);
		newAmount = new Vector2 (time *21.25f, 0);
		oldAmount = newAmount;
		
		maxDistanceMoved2 = new Vector2 (-285.5f, -951);
		newAmount2 = new Vector2 (time2 *21.25f, 0);
		oldAmount2 = newAmount2;
		
		maxDistanceMoved3 = new Vector2 (-285.5f, -1686);
		newAmount3 = new Vector2 (time3 *21.25f, 0);
		oldAmount3 = newAmount3;
		
		maxDistanceMoved4 = new Vector2 (-285.5f, -2452);
		newAmount4 = new Vector2 (time4 *21.25f, 0);
		oldAmount4 = newAmount4;
		
		// Timer 1
		if (timerOn) {
			if
			(time < timerMax) {
				timerRaw.rectTransform.sizeDelta = new Vector2 ((time * 21.25f), 170f); // This equation moves the timer to the far left of the blank timer bar so that it fills from left to right.
				maxDistanceMoved = maxDistanceMoved + (newAmount - oldAmount/2);
				timerRaw.rectTransform.localPosition = maxDistanceMoved;
				timerRaw.material = green;
				uiHandler.toggleInteractableButton (1, false);
			} else {
				uiHandler.toggleInteractableButton (1, true);
				if (toggle) {
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle = false; // Reset toggle so the sound only plays once.
					timerRaw.material = white;
				}
			}
		} else { // If the timer is off, turn off and hide the timer and blackBar beneath it.
			timerRaw.gameObject.SetActive(false);
			blackBar.enabled = false;
		}
		if (!pause){
			time = time + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (1)); // Speed of timer is affected by its animal's attack's speed multiplier.
		}
		
		// Timer 2
		if (timerOn2) {
			if (time2 < timerMax) {
				timerRaw2.rectTransform.sizeDelta = new Vector2 ((time2 * 21.25f), 170f);
				maxDistanceMoved2 = maxDistanceMoved2 + (newAmount2 - oldAmount2/2);
				timerRaw2.rectTransform.localPosition = maxDistanceMoved2;
				timerRaw2.material = green;
				uiHandler.toggleInteractableButton (2, false);
			} else {
				uiHandler.toggleInteractableButton (2, true);
				if (toggle2) {
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle2 = false;
					timerRaw2.material = white;
				}
			}
		} else {
			timerRaw2.gameObject.SetActive(false);
			blackBar2.enabled = false;
		}
		if (!pause2) {
			time2 = time2 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (2));
		}
		
		// Timer 3
		if (timerOn3) {
			if (time3 < timerMax) {
				timerRaw3.rectTransform.sizeDelta = new Vector2((time3*21.25f) ,170f);
				maxDistanceMoved3 = maxDistanceMoved3 + (newAmount3 - oldAmount3/2);
				timerRaw3.rectTransform.localPosition = maxDistanceMoved3;
				timerRaw3.material = green;
				uiHandler.toggleInteractableButton (3, false);
			} else {
				uiHandler.toggleInteractableButton (3, true);
				if (toggle3){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle3 = false;
					timerRaw3.material = white;
				}
			}
		}else {
			//timerRaw3.enabled = false;
			timerRaw3.gameObject.SetActive(false);
			blackBar3.enabled = false;
		}
		if (!pause3) {
			time3 = time3 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (3));
		}
		
		// Timer 4
		if (timerOn4) {
			if (time4 < timerMax) {
				timerRaw4.rectTransform.sizeDelta = new Vector2((time4*21.25f) ,170f);
				maxDistanceMoved4 = maxDistanceMoved4 + (newAmount4 - oldAmount4/2);
				timerRaw4.rectTransform.localPosition = maxDistanceMoved4;
				timerRaw4.material = green;
				uiHandler.toggleInteractableButton (4, false);
			} else {
				uiHandler.toggleInteractableButton (4, true);
				if (toggle4){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle4 = false;
					timerRaw4.material = white;
				}
			}
		}else {
			timerRaw4.gameObject.SetActive(false);
			blackBar4.enabled = false;
		}
		if (!pause4){
			time4 = time4 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (4));
		}
		
	}

	public void ResetTimer(int i){ //Resets the timer.
		switch (i) {
		case 1:
			time = 0; // Resets the timer counter to zero.		
			toggle = true; // Turns toggle back to true, allowing timer sound to only play once and timer to turn white when filled.
			break;
		case 2:
			time2 = 0;
			toggle2 = true;
			break;
		case 3:
			time3 = 0;
			toggle3 = true;
			break;
		case 4:
			time4 = 0;
			toggle4 = true;
			break;
		}
	}
	
	public void toggleTimer(int buttonNum, bool onOrOff){ // Turns on or off the display of a timer.
		switch (buttonNum) {
		case 1:
			timerOn = onOrOff;
			break;
		case 2:
			timerOn2 = onOrOff;
			break;
		case 3:
			timerOn3 = onOrOff;
			break;
		case 4:
			timerOn4 = onOrOff;
			break;
		}
	}
	
	public void pauseTimer(int buttonNum, bool onOrOff){ // Turns on or off the increase of time of a timer (does not affect visibility).
		switch (buttonNum) {
		case 1:
			pause = onOrOff;
			break;
		case 2:
			pause2 = onOrOff;
			break;
		case 3:
			pause3 = onOrOff;
			break;
		case 4:
			pause4 = onOrOff;
			break;
		}
	}
}
