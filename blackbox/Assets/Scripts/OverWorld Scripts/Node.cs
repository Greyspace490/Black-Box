using UnityEngine;
using System.Collections;

// Node handles the movement on the overworld.  When the movement handler sends a player into a node, the
// collision is detected. Node tells MovementHandler which directions are valid to leave from, and depending
// on certain triggers, will allow the player to trigger an event with the space key or will automatically
// trigger.

public class Node : MonoBehaviour {

	MovementHandler movementHandler;
	
	public bool canGoLeft; // Allows the player to move off the node in this direction .
	public bool canGoRight;
	public bool canGoUp;
	public bool canGoDown;
	public bool autoEvent; // Plays the event whether or not the player intiates it.
	public bool searchEvent = false; // Plays only if the player decides to interact with the node.
	public bool eventRepeatable; // Let's the player play the vent more than once.
	public int eventNumber; // The number of the event for the EventManager to play.
	public bool muteSound; // Stops the standard sound that plays when the player steps on a node.
	public AudioClip fight; // Plays a fight sound when the player enters a fight
	public bool givePlayerAnimal; // If set to true, the player will receive the following animal.
	public Animal playerAnimal; // Gives the player an Animal of this type.
	public bool playBattle; // Sends the player to a battle using the following details.
	public Animal enemyAnimal; // Animal to be fought
	public AI ai; // The way that this animal will fight.  If nothing is assigned, the standard AI will be used.
	public Sprite battleBackground; // The background of the battle.  For example: field, city, desert.

	Chibi chibi; // The player's movement model.
	SupraEvent eventManager; // Plays events, such as dialogue or fights.
	bool turnOnEvent; // Triggers the possibility of the event playing after chibi has settled to the center of the node, for example.
	bool eventPlayed; // Trigger for whether or not an event has been played before. Can determine whether that event can happen again.
	bool triggerMoveToCenter; // Moves the player to the center of the node to ensure they don't get off track.
	bool playerStartedHere = false; // Trigger that tells that the player started on this node, which means the node sound should not be played for them.
	AudioSource sfx; // The sound player of this node, which plays the beeping sound that plays when the player lands on the node.
	AudioSource musicPlayer; // The music player for the scene, to be muted when a battle commences.
	Save save; // The save that the node accesses for information on player location and enemy and player animals
	float timerBeforeMoving = 0; // If the player gets stuck for 3 seconds, just move them to the center of the node.
	bool chibiInCenter = false; // Indicates if the chibi is in the center of the node for use with timerBeforeMoving.

	Node(){
		triggerMoveToCenter = false;
		turnOnEvent = false;
	}

	void Awake(){
		save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
		eventPlayed = save.CheckNode(eventNumber); // Checks Save to see if the player has visited this node before.

		if (playBattle && save.CheckNode (eventNumber)) // Battles that are not repeatable are removed entirely from the map.
			Destroy (gameObject);
	}

	void Start(){
		movementHandler = GameObject.Find ("MovementHandler").GetComponent<MovementHandler> ();
		chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
		eventManager = GameObject.FindGameObjectWithTag ("EventManager").GetComponent<SupraEvent> ();

		// Stops the node sound from playing if the player starts on the node.
		if (chibi.transform.position == transform.position) { 
			muteSound = true;
			playerStartedHere = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D collider){
		chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		triggerMoveToCenter = true;
	}

	public void OnTriggerExit2D(Collider2D col){
		timerBeforeMoving = 0; 
		chibiInCenter = false; 
	}


	void Update(){
		// The following sets the player in the direct center of the node to avoid them from derailing,
		// stops their movement, and sets possible exit directions from this node in MovementHandler.
		// It also will turn the turnEvent trigger on if this is an autoevent, meaning that the vent 
		// will immediately play.

		if (eventRepeatable){ // Makes sure that repeatable events are checked for 
			eventPlayed = save.CheckNode(eventNumber);
		}
		if (triggerMoveToCenter) {
			chibi.transform.position = Vector3.MoveTowards(chibi.transform.position, transform.position, (movementHandler.getSpeedOfMovement()) * Time.deltaTime);

			// This ensures that if the player gets stuck, they get repositioned.
			timerBeforeMoving = timerBeforeMoving + (1f * Time.deltaTime);
			if (timerBeforeMoving > 2 && !chibiInCenter){ 
				chibi.transform.position = transform.position;
				chibiInCenter = true;
			}

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
			if(Input.GetKeyDown(KeyCode.F) && chibi.transform.position == transform.position){
				turnOnEvent = true;
			}
		}

		// If this is an autoevent, this plays automatically. Or, if it is a search event and the player
		// decides to search, it plays the event.  The event played is decided by eventNumber.
		if (turnOnEvent && !eventPlayed && chibi.transform.position == transform.position) { // Makes sure that 1. the player has acess to the event, 2. the event hasn't been played already, and 3. that the player is actually sitting on this event (which stops them from triggering it after walking away)
			eventPlayed = true;
			turnOnEvent = false;

			save.AddNode(eventNumber);

			if(givePlayerAnimal) // Give the player an animal if the Node calls for it.
			{
				save.setPlayerAnimal(playerAnimal);
			}

			eventManager.playEvent(eventNumber); // The event to be played.

			if (playBattle){ // Battle
				save.setDirections(canGoLeft, canGoRight, canGoUp, canGoDown);
				save.setBattleBG(battleBackground);
				save.setCameraLocation(GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition);

				sfx = GetComponent<AudioSource>();
				sfx.clip = fight;
				sfx.Play();

				musicPlayer = GameObject.FindWithTag ("MusicPlayer").GetComponent<AudioSource> ();
				musicPlayer.mute = true;

				save.setEnemyAnimal(enemyAnimal); // Save the enemy the player will fight to the Save object.
				save.setAI(ai); // Save the AI that the player will face.
				save.setPreviousLocation(chibi.transform.localPosition); // Save this location's coordinates for the player to return to after the battle.
				save.setPreviousLevel(Application.loadedLevel); // Set this location's level for the player to return to.
	
				Application.LoadLevel(1); // Load battle scene.
			}

			if (eventRepeatable){ // If the event is repeatable, this event can keep being triggered, so it is deleted from the Save as if it was never visited.
				save.RemoveNode(eventNumber);
			}
		}
	}

	IEnumerator Pause(float x){
		yield return new WaitForSeconds(x);
	}
}
