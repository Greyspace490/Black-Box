using UnityEngine;
using System.Collections;

// Handles Chibi Kayla's movement.  Once a direction is hit, the player can't move until she has reached 
// a node. Also has functions to let other classes know if she can walk in any given direction or what
// direction she is walking in or facing. MovementHandler also places the chibi at the correct location
// depending on what is saved in the persistent Save object.

public class MovementHandler : MonoBehaviour {

	Chibi chibi; // The player's representation (what actually walks around the map.
	Direction walkingState; // Enum representing the direction the player is walking (Direction.movingDown) or facing (Direction.down)
	public float SpeedOfMovement; // Speed that the player moves.
	public bool canGoLeft; // Triggers that allow/disallow the player from going in any direction. This is updated by the nodes that the player lands on.
	public bool canGoRight;
	public bool canGoUp;
	public bool canGoDown;
	public Canvas canvas1; // If these canvasses are displayed, it means a dialogue is happening, and movement is not allowed.
	public Canvas canvas2;
	Save save;

	MovementHandler(){
		walkingState = Direction.down; // Player starts off facing the camera.
	}
	
	void Awake(){
		chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
		save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;

		// Retrieve information from Save object.
		if (save.getNewLocation() != new Vector3(0,0,0))
			chibi.transform.localPosition = save.getNewLocation(); // Sets the player's starting position on the map.
		save.setNewLocation(new Vector3(0,0,0));
		canGoLeft = save.GetLeft (); // Get directions player can move.
		canGoRight = save.GetRight ();
		canGoUp = save.GetUp ();
		canGoDown = save.GetDown();
	}

	void Update () {

		//The following section listens for the arrows or WASD, then moves the player in that direction
		// at the rate of SpeedOfMovement, then disallows any more button presses.  These directions
		// are restored upon entering a node.

		// Left
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) && canGoLeft && !canvas1.enabled && !canvas2.enabled) { // The player must hit an arrow or WASD, be allowed to go in the direction pressed, and a canvas can not be displayed (meaning that a dialogue is in action)
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-SpeedOfMovement, 0f, 0f);
			walkingState = Direction.movingLeft;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Right
		if ((Input.GetKeyDown (KeyCode.RightArrow) | Input.GetKeyDown (KeyCode.D)) && canGoRight && !canvas1.enabled && !canvas2.enabled) {
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(SpeedOfMovement, 0f, 0f);
			walkingState = Direction.movingRight;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Up
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && canGoUp && !canvas1.enabled && !canvas2.enabled) {
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, SpeedOfMovement, 0f);
			walkingState = Direction.movingUp;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Down
		if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && canGoDown && !canvas1.enabled && !canvas2.enabled) {
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, -SpeedOfMovement, 0f);
			walkingState = Direction.movingDown;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}
	}

	// Allows other classes access to the last pressed walking state.
	public Direction getWalkingState(){ 
		return walkingState;
	}

	// Allows other classes to set a walking state.
	public void setWalkingState(Direction dir){ 
		walkingState = dir;
	}

	// Allows other classes to see what speed Kayla is moving at.
	public float getSpeedOfMovement(){
		return SpeedOfMovement;
	}

	// Stops the player, and sets their walking state to the correct static movement status.
	public void Stop(){
		if (walkingState == Direction.movingLeft)
			walkingState = Direction.left;
		if (walkingState == Direction.movingRight)
			walkingState = Direction.right;
		if (walkingState == Direction.movingUp)
			walkingState = Direction.up;
		if (walkingState == Direction.movingDown)
			walkingState = Direction.down;

		chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
	}

	// Allows other classes to set the directions that can be walked when buttons are pressed again.
	public void setDirections(bool left, bool right, bool up, bool down){
		canGoLeft = left;
		canGoRight = right;
		canGoUp = up;
		canGoDown = down;
	}

	// The following returns the available directions the player is capable of moving.
	public bool GetLeft(){
		return canGoLeft;
	}

	public bool GetRight(){
		return canGoRight;
	}

	public bool GetUp(){
		return canGoUp;
	}

	public bool GetDown(){
		return canGoDown;
	}
}

