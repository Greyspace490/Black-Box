using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// UIHandler manages the UI, removing buttons depending on which animal is equipped (some animals have more
// attacks than others) and allowing access to buttons depending on messages sent to it.
//

public class UIHandler : MonoBehaviour {

	public Button attack; // Attack buttons for the player.
	public Button attack2;
	public Button attack3;
	public Button attack4;
	public Player player;
	
	void Awake () { // Disable and hide all buttons 
		attack2.interactable = false;
		attack2.gameObject.SetActive (false);

		attack3.interactable = false;
		attack3.gameObject.SetActive (false);

		attack4.interactable = false;
		attack4.gameObject.SetActive (false);
	}

	void Start(){
		refreshButtons (); // Checks to see how many buttons should be placed, then places them.
	}

	public void toggleInteractableButton(int buttonNum, bool yes){ // Toggles clickability of button.
		if (yes) { // True/yes turns on the button number buttonNum.
			switch (buttonNum) {
			case 4:
				attack4.interactable = true;
				break;
			case 3:
				attack3.interactable = true;
				break;
			case 2:
				attack2.interactable = true;
				break;
			case 1:
				attack.interactable = true;
				break;
			}
		}else { // False/no turns on the button number buttonNum.
			switch (buttonNum) {
			case 4:
				attack4.interactable = false;
				break;
			case 3:
				attack3.interactable = false;
				break;
			case 2:
				attack2.interactable = false;
				break;
			case 1:
				attack.interactable = false;
				break;
			}
			}
	}

	public void refreshButtons(){ // Unhides all buttons that the player's animal allows, and names those buttons.
		int buttons = player.checkAttacks ();

		switch (buttons) { //Unhides buttons.
		case 4:
			attack4.gameObject.SetActive (true);
			goto case 3;
		case 3:
			attack3.gameObject.SetActive (true);
			goto case 2;
		case 2:
			attack2.gameObject.SetActive (true);
			goto case 1;
		case 1:
			attack.gameObject.SetActive (true);
			break;
		}
	
		switch (buttons){ // Names buttons
		case 4:
			attack4.GetComponentInChildren<Text>().text = player.getAttackNames(4); 
			goto case 3;
		case 3:
			attack3.GetComponentInChildren<Text>().text = player.getAttackNames(3);
			goto case 2;
		case 2:
			attack2.GetComponentInChildren<Text>().text = player.getAttackNames(2);
			goto case 1;
		case 1:
			attack.GetComponentInChildren<Text>().text = player.getAttackNames(1);
			break;
		}
	}
}
