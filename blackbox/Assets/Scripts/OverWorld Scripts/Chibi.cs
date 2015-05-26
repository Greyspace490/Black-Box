using UnityEngine;
using System.Collections;

// Chibi performs two functions, primarily:
// 1. Updates its object's animations depending on the direction it is moving, or whether it has stopped.
// 2. Identifies its object as Chibi, allowing for other functions to find and act upon it.
// 3. Note that movement and movement states are handled by MovementHandler, not Chibi.

public class Chibi : MonoBehaviour {
	
	MovementHandler movementHandler;
	Direction walkingState;
	
	void Start () {
		movementHandler = (GameObject.Find ("MovementHandler").GetComponent<MovementHandler> ()) as MovementHandler;
	}

	void Update () {

		walkingState = movementHandler.getWalkingState (); // Retrieves current walking state from MovementHandler.

		// Make KaylaChibi play a walking animation if she is moving.
		if (walkingState == Direction.movingLeft) {
			GetComponent<Animator>().Play("MovingLeft");
		}

		if (walkingState == Direction.movingRight) {
			GetComponent<Animator>().Play("MovingRight");
		}
		
		if (walkingState == Direction.movingUp) {
			GetComponent<Animator>().Play("MovingUp");
		}
		
		if (walkingState == Direction.movingDown) {
			GetComponent<Animator>().Play("MovingDown");
		}

		// Plays Kayla's "static" animations if she has stopped moving.
		if (walkingState == Direction.left) {
			GetComponent<Animator>().Play("Left");
		}
		
		if (walkingState == Direction.right) {
			GetComponent<Animator>().Play("Right");
		}
		if (walkingState == Direction.up) {
			GetComponent<Animator>().Play("Up");
		}
		
		if (walkingState == Direction.down) {
			GetComponent<Animator>().Play("Down");
		}
	}
}
