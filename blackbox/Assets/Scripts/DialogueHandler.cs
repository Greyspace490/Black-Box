using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// The DialogueHandler displays dialogues on the screen. It has two methods.  The first plays a dialogue
// meant for two people talking to each other, and and the second displays a single dialogue box. Each
// takes at least one string for the person's name, one strong for the location of their portrait (which
// can be referenced by a static Portrait class for ease of use) and finally, their actual dialogue which
// needs to be 160 characters max to fit in the dialogue.

public class DialogueHandler : MonoBehaviour {
	
	// The following are all tied to the Dialogue Boxes, text in those boxes, and portrait attached
	//to those boxes.
	public Text speaker; // The name of the person speaking.
	public Text speaker2;
	public GameObject portrait1; // The portrait of the person speaking. Refer to using constants, below.
	public GameObject portrait2;
	public Text dialogue; // The dialogue to be said; should be 160 characters (w/ spaces) or less
	public Text dialogue2;
	public Canvas canvas1; // The canvas that the dialogues sit on to be hidden after dialogue finishes.
	public Canvas canvas2;
	bool isRunning = false; // A trigger that determines whether a dialogue is currently running to disallow the coroutine from running on top of another. 
		
	// Shows a two person dialogue
	public IEnumerator showMessage(string speaking1, string face1, string newMessage1,  string speaking2, string face2, string newMessage2){
		while (isRunning) { // Checks to see if an instance of this coroutine is running, and if so, it will wait.
			yield return null;
		} 

		isRunning = true; 

		speaker.text = speaking1; // Assign the dialogue.
		speaker2.text = speaking2;
		
		dialogue.text = newMessage1; // Assign the speaker's name.
		dialogue2.text = newMessage2;
		
		portrait1.GetComponent<Image>().sprite  = Resources.Load<Sprite>(face1); // Assigns portraits.
		portrait2.GetComponent<Image>().sprite  = Resources.Load<Sprite>(face2);
		
		// Shows first dialogue box.
		canvas1.enabled = true;

		// Pauses at the first dialogue box until the player clicks to proceed dialogue.
		yield return StartCoroutine(WaitForKey(KeyCode.Space));
		
		// Pauses.
		yield return new WaitForSeconds(.4f);
		
		// Shows second dialogue box.
		canvas2.enabled = true;
		
		// Keeps dialogue up until player presses the spacebar.
		yield return StartCoroutine(WaitForKey(KeyCode.Space));

		// Pauses.
		yield return new WaitForSeconds(.4f);
		
		// Resets canvasses to be invisible.
		canvas1.enabled = false;
		canvas2.enabled = false;
		isRunning = false;
	}

	// Shows a one person dialogue
	public IEnumerator showMessage(string speaking1, string face1, string newMessage1){
		while (isRunning) { // Checks to see if an instance of this coroutine is running, and if so, it will wait.
			yield return null;
		} 
		
		isRunning = true; 
		
		speaker.text = speaking1; // Assign the dialogue.
		dialogue.text = newMessage1; // Assign the speaker's name.	
		portrait1.GetComponent<Image>().sprite  = Resources.Load<Sprite>(face1); // Assigns portraits.
	
		
		// Shows dialogue box.
		canvas1.enabled = true;
		
		// Pauses at the dialogue box until the player clicks to proceed dialogue.
		yield return StartCoroutine(WaitForKey(KeyCode.Space));
		
		// Pauses.
		yield return new WaitForSeconds(.4f);

		// Resets canvas to be invisible.
		canvas1.enabled = false;
		isRunning = false;
	}

	IEnumerator WaitForKey(KeyCode i)
	{
		while (!Input.GetButtonUp("Submit")) { // Waits for the player to press, then release, the space or enter button.
			yield return null;
		}

	}
}
