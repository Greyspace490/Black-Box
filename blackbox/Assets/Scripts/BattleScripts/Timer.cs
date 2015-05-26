using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

//  The Timer keeps track of the Player's ability to select attacks, activates buttons to allow attack, and updates a timer UI element
//  to show the amount of time left before the Player can attack again.
//  

public class Timer : MonoBehaviour {

	public AudioClip timerSound;
	//since this is the audiosource attached to this object, i can probably make this private and prefer to it directly.
	public AudioSource sfxPlayer;
	public float timerWidth; // X coordinate for all timers' placement.
	public float timerHeight; // Y coordinate for timer's placement.
	public float timerHeight2; 
	public float timerHeight3; 
	public float timerHeight4; 
	
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
	Rect timeBarRect; // The bar coordinates.
	Rect timeBarRect2; 
	Rect timeBarRect3; 
	Rect timeBarRect4; 
	Texture2D timeTexture; // Color of bar when it is filling.
	Texture2D timeTextureFlash; // Color of bar when it is full.
	int timerMax; // What float time must reach before the timer is considered full.
	Player player; // Access to the player, so that their Speed stat can be accessed for the timer.
	UIHandler uiHandler; // Access to UIHandler to toggle button properties.
	Camera cam; // The main camera, which is used to set the Rect coordinates relative to the camera so that timers resize relative to window size regardless of whether the game is aspect ratio or not.

	void Start (){

		player = (GameObject.FindWithTag ("Player").GetComponent<Player> ()) as Player;
		uiHandler = (GameObject.FindWithTag ("UIHandler").GetComponent<UIHandler> ()) as UIHandler;

		//Defaults time for each bar at 0.
		time = 0; 
		time2 = 0;
		time3 = 0;
		time4 = 0;

		toggle = true;
		toggle2 = true;
		toggle3 = true;
		toggle4 = true;

		//  Turns on/off the timers according to whether the player's animal has attacks for those timers.
		timerOn = false;
		timerOn2 = false;
		timerOn3 = false;
		timerOn4 = false;
		switch (player.checkButtons()) {
		case 4:
			timerOn4 = true;
			goto case 3;
		case 3:
			timerOn3 = true;
			goto case 2;
		case 2:
			timerOn2 = true;
			goto case 1;
		case 1:
			timerOn = true;
			break;
		}

		// Set timer placement coordinates
		timerHeight = 1.528f;
		timerHeight2 = 0.688f;
		timerHeight3 = .623f;
		timerHeight4 = .572f;

		timerWidth = 4.54f;

		// Initialization of the main camera, to be used to place the timerbar.
		cam = (GameObject.FindWithTag("MainCamera").GetComponent<Camera>()) as Camera;

		// Initializiation of the player's timer bars.
		timeBarRect = new Rect(0, 0, Screen.width / 3, Screen.height / 50); //Set size and location of bar.
		timeBarRect2 = new Rect(0, 0, Screen.width / 3, Screen.height / 50); //Set size and location of bar.
		timeBarRect3 = new Rect(0, 0, Screen.width / 3, Screen.height / 50); //Set size and location of bar.
		timeBarRect4 = new Rect(0, 0, Screen.width / 3, Screen.height / 50); //Set size and location of bar.

		// Set color and texture of timer bar when filling.
		timeTexture = new Texture2D (1, 1);
		timeTexture.SetPixel(0,0, Color.green);
		timeTexture.Apply();

		// Set color and texture of timer bar when full.
		timeTextureFlash = new Texture2D (1, 1);
		timeTextureFlash.SetPixel(0,0, Color.white);
		timeTextureFlash.Apply();

		timerMax = (200 - player.getSpeed()); // Sets the timer to align with the player's speed.
	}

	void Update () // Here, the timer is filled.
	{
		// Update speed changes in player's stats.
		// Note: Right now, changes, especially big ones, affect the size of the timer on the screen.  Need to fix this.
		timerMax = (200 - player.getSpeed()); 

		// Updates where the timerbar lies relative to the screen dimensions changing.
		timeBarRect.x = cam.pixelWidth / timerWidth;
		timeBarRect.y = cam.pixelHeight / timerHeight;

		timeBarRect2.x = cam.pixelWidth / timerWidth;
		timeBarRect2.y = cam.pixelHeight / (timerHeight2 * 2);

		timeBarRect3.x = cam.pixelWidth / timerWidth;
		timeBarRect3.y = cam.pixelHeight / (timerHeight3 * 2);

		timeBarRect4.x = cam.pixelWidth / timerWidth;
		timeBarRect4.y = cam.pixelHeight / (timerHeight4 * 2);

		// The following all deals with the ticking of the timer and the player's ability to attack.

		// Timer 1
		if (timerOn) {
			if (time < timerMax) {
				uiHandler.toggleInteractableButton (1, false);
				time = time + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (1)); // Speed of timer is affected by its animal's attack's speed multiplier.
			} else {
				uiHandler.toggleInteractableButton (1, true);
				if (toggle){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle = false; // Reset toggle so the sound only plays once.
				}
			}
		}

		// Timer 2
		if (timerOn2) {
			if (time2 < timerMax) {
				uiHandler.toggleInteractableButton (2, false);
				time2 = time2 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (2));
			} else {
				uiHandler.toggleInteractableButton (2, true);
				if (toggle2){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle2 = false;
				}
			}
		}

		// Timer 3
		if (timerOn3) {
			if (time3 < timerMax) {
				uiHandler.toggleInteractableButton (3, false);
				time3 = time3 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (3));
			} else {
				uiHandler.toggleInteractableButton (3, true);
				if (toggle3){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle3 = false;
				}
			}
		}

		// Timer 4
		if (timerOn4) {
			if (time4 < timerMax) {
				uiHandler.toggleInteractableButton (4, false);
				time4 = time4 + ((10 * Time.deltaTime) * player.getAttackSpeedMultiplier (4));
			} else {
				uiHandler.toggleInteractableButton (4, true);
				if (toggle4){
					sfxPlayer.clip = timerSound;
					sfxPlayer.Play ();
					toggle4 = false;
				}
			}
		}
	}

	void OnGUI(){ // Updates the timer UI on the screen.

		// All of the following deals with the animation/creation of the timer bar.

		// Timer 1
		timeBarRect.width = ((time * Screen.width * .1f)/timerMax); // Timer size on screen scaled for screen resizes, and also scaled so timer is the same size regardless of size of timerMax. 
		GUI.DrawTexture (timeBarRect, timeTexture);
		if (toggle) { // Change color of timer if it is full.
				GUI.DrawTexture (timeBarRect, timeTextureFlash);
			}

		// Timer 2
		timeBarRect2.width = ((time2 * Screen.width * .1f)/timerMax); 
		GUI.DrawTexture (timeBarRect2, timeTexture);
		if (toggle2) { 
			GUI.DrawTexture (timeBarRect2, timeTextureFlash);
		}

		// Timer 3
		timeBarRect3.width = ((time3 * Screen.width * .1f)/timerMax); 
		GUI.DrawTexture (timeBarRect3, timeTexture);
		if (toggle3) { 
			GUI.DrawTexture (timeBarRect3, timeTextureFlash);
		}

		// Timer 4
		timeBarRect4.width = ((time4 * Screen.width * .1f)/timerMax); 
		GUI.DrawTexture (timeBarRect4, timeTexture);
		if (toggle4) { 
			GUI.DrawTexture (timeBarRect4, timeTextureFlash);
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

	public void toggleTimer(int buttonNum, bool onOrOff){ // Turns on or off a timer (does not affect visibility, but timers that start off have nothing drawn to screen yet and appear to be missing.).
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
}
