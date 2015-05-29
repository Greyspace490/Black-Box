using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {

	Chibi chibi; // The player's representation (what actually walks around the map.
	Direction walkingState; // Enum representing the direction the player is walking (Direction.movingDown) or facing (Direction.down)
	public float SpeedOfMovement; // Speed that the player moves.
	public bool canGoLeft; // Triggers that allow/disallow the player from going in any direction. This is updated by the nodes that the player lands on.
	public bool canGoRight;
	public bool canGoUp;
	public bool canGoDown;
	bool tempCanGoLeft; // Saves the walking state of the player to allow the disallowing of them from walking during dialogue.
	bool tempCanGoRight;
	bool tempCanGoUp;
	bool tempCanGoDown;
	
	MovementHandler(){
		walkingState = Direction.down; // Player starts off facing the camera.
	}

	void Awake(){
		chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
	}

	void Update () {

		//The following section listens for the arrows or WASD, then moves the player in that direction
		// at the rate of SpeedOfMovement, then disallows any more button presses.  These directions
		// are restored upon entering a node.

		// Left
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) && canGoLeft) {
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-SpeedOfMovement, 0f, 0f);
			walkingState = Direction.movingLeft;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Right
		if ((Input.GetKeyDown (KeyCode.RightArrow) | Input.GetKeyDown (KeyCode.D)) && canGoRight) {
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(SpeedOfMovement, 0f, 0f);
			walkingState = Direction.movingRight;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Up
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && canGoUp) {
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, SpeedOfMovement, 0f);
			walkingState = Direction.movingUp;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Down
		if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && canGoDown) {
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

	public void setTempDirections(bool left, bool right, bool up, bool down){
		tempCanGoLeft = left;
		tempCanGoRight = right;
		tempCanGoUp = up;
		tempCanGoDown = down;
	}

	public bool GetTempLeft(){
		return tempCanGoLeft;
	}
	
	public bool GetTempRight(){
		return tempCanGoRight;
	}
	
	public bool GetTempUp(){
		return tempCanGoUp;
	}
	
	public bool GetTempDown(){
		return tempCanGoDown;
	}





}

