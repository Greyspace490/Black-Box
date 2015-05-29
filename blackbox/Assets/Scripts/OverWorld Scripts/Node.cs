using UnityEngine;
using System.Collections;

// Node handles the movement on the overworld.  When the movement handler sends a player into a node, the
// collision is detected. Node tells MovementHandler which directions are valid to leave from, and depending
// on certain triggers, will allow the player to trigger an event with the space key or will automatically
// trigger.

public class Node : MonoBehaviour {

	MovementHandler movementHandler;

	Chibi chibi; // The player's movement model.
	EventManager eventManager; // Plays events, such as dialogue or fights.
	bool turnOnEvent; // Triggers the possibility of the event playing after chibi has settled to the center of the node, for example.
	bool eventPlayed; // Trigger for whether or not an event has been played before. Can determine whether that event can happen again.
	bool triggerMoveToCenter; // Moves the player to the center of the node to ensure they don't get off track.
	bool playerStartedHere = false; // Trigger that tells that the player started on this node, which means the node sound should not be played for them.
	AudioSource sfx; // The sound player of this node, which plays the beeping sound that plays when the player lands on the node.
	public bool canGoLeft; // Allows the player to move off the node in this direction .
	public bool canGoRight;
	public bool canGoUp;
	public bool canGoDown;
	public bool autoEvent; // Plays the event whether or not the player intiates it.
	public bool searchEvent = false; // Plays only if the player decides to interact with the node.
	public bool eventRepeatable; // Let's the player play the vent more than once.
	public int eventNumber; // The number of the event for the EventManager to play.
	public bool muteSound; // Stops the standard sound that plays when the player steps on a node.

	Node(){
		triggerMoveToCenter = false;
		turnOnEvent = false;
		eventPlayed = false;
	}

	void Start(){
		movementHandler = GameObject.Find ("MovementHandler").GetComponent<MovementHandler> ();
		chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
		eventManager = GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ();
		if (chibi.transform.position == transform.position) {
			muteSound = true;
			playerStartedHere = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider){
		chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		triggerMoveToCenter = true;
		}

	void Update(){
		// The following sets the player in the direct center of the node to avoid them from derailing,
		// stops their movement, and sets possible exit directions from this node in MovementHandler.
		// It also will turn the turnEvent trigger on if this is an autoevent, meaning that the vent 
		// will immediately play.
		if (triggerMoveToCenter) {
			chibi.transform.position = Vector3.MoveTowards(chibi.transform.position, transform.position, (movementHandler.getSpeedOfMovement()) * Time.deltaTime);

			if (chibi.transform.position == transform.position) {
				triggerMoveToCenter = false;

				// Plays the beep sound for when the player makes contact with the node.
				if (!muteSound){
					sfx = GetComponent<AudioSource>();
					sfx.Play();
				}

				if (playerStartedHere) // Turns the node sound back on so that if the player returns to the node, it makes noise.
				{
					muteSound = false;
				}

				chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
				movementHandler.Stop ();

				movementHandler.setDirections(canGoLeft, canGoRight, canGoUp, canGoDown); // Allows movement from the node.
				movementHandler.setTempDirections(canGoLeft, canGoRight, canGoUp, canGoDown); // Saves movement in case of dialogue.

				// Happens if an event automatically happens regardless of player decision, such as for battles.
				if (autoEvent){
					turnOnEvent = true;
				}
			}
		}

		// Some events need to be interacted with in order to play their event.  For instance, to search a
		// house or talk to a person on the road. If this is a searchEvent, the player must press space
		// to initiate it.
		if (searchEvent && !eventPlayed){
			if(Input.GetKeyUp (KeyCode.F)){
				turnOnEvent = true;
			}
		}

		// If this is an autoevent, this plays automatically. Or, if it is a search event and the player
		// decides to search, it plays the event.  The event played is decided by eventNumber.
		if (turnOnEvent && !eventPlayed && chibi.transform.position == transform.position) { // Makes sure that 1. the player has acess to the event, 2. the event hasn't been played already, and 3. that the player is actually sitting on this event (which stops them from triggering it after walking away)
			eventPlayed = true;
			turnOnEvent = false;

			eventManager.playEvent(eventNumber); // The event to be played.

			if (eventRepeatable){ // If the event is repeatable, this event can keep being triggered, so all tags are reset.
				eventPlayed = false;
			}
		}
	}

	IEnumerator Pause(float x){
		yield return new WaitForSeconds(x);
	}
}
