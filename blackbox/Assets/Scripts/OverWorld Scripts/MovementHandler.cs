using UnityEngine;
using System.Collections;

public class MovementHandler : MonoBehaviour {

	Chibi chibi; // The player's representation (what actually walks around the map.
	Direction walkingState; // Enum representing the direction the player is walking (Direction.movingDown) or facing (Direction.down)
	public int SpeedOfMovement; // Speed that the player moves.
	public bool canGoLeft; // Triggers that allow/disallow the player from going in any direction. This is updated by the nodes that the player lands on.
	public bool canGoRight;
	public bool canGoUp;
	public bool canGoDown;
	
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
			Debug.Log ("left");
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-SpeedOfMovement, 0, 0);
			walkingState = Direction.movingLeft;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Right
		if ((Input.GetKeyDown (KeyCode.RightArrow) | Input.GetKeyDown (KeyCode.D)) && canGoRight) {
			Debug.Log ("right");
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(SpeedOfMovement, 0, 0);
			walkingState = Direction.movingRight;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Up
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) && canGoUp) {
			Debug.Log ("up");
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, SpeedOfMovement, 0);
			walkingState = Direction.movingUp;
			canGoLeft = false;
			canGoRight = false;
			canGoUp = false;
			canGoDown = false;
		}

		// Down
		if ((Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) && canGoDown) {
			Debug.Log ("down");
			chibi.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -SpeedOfMovement, 0);
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
	public int getSpeedOfMovement(){
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
}

