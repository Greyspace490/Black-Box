using UnityEngine;
using System.Collections;

// WindmillScriptedEvent is a cutscene that displays text and moves the chibi around the screen.
//
//

public class WindmillScriptedEvent : MonoBehaviour {

	public GameObject dialogue1; 
	public GameObject dialogue2;
	public MovementHandler mh;
	public Chibi chibi;
	public FadeOut fade; // Used to fade scene in and out.
	float timer = 0; // Timer, used in order to display each event in cutscene at a specific moment.



	// The following triggers allow each event in the script to proceed.  The number corresponds to the timer value.
	public float trigger1 = 1f;
	public float trigger2 = 5f;
	public float trigger3 = 6f;
	public float trigger4 = 9f;
	public float trigger5 = 11f;
	public float trigger6 = 13f;
	public float trigger7 = 15f;
	public float trigger8 = 17f;
	public float trigger9 = 19f;
	public float trigger10 = 20f;


	void Update () {

		timer = timer + (1 * Time.deltaTime);

		// Dialogue: Welcome home
		if (timer > trigger1 && timer < trigger1+1) {
			dialogue1.SetActive(true);
		}

		// Dialogue off
		if (timer > trigger2 && timer < trigger2+1) {
			dialogue1.SetActive(false);

		}

		// Face chibi up.
		if (timer > trigger3 && timer < trigger3+1){
			mh.setWalkingState (Direction.up);
		}

		// Walk right.
		if (timer >trigger4 && timer < trigger4+1){
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(.5f, 0f, 0f);
			mh.setWalkingState(Direction.movingRight);
		}

		// Stop walking.
		if (timer >trigger5 && timer < trigger5+1){
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(.0f, 0f, 0f);

			mh.setWalkingState(Direction.right);
		}

		// Face up again.
		if (timer >trigger6 && timer < trigger6+1){
			mh.setWalkingState(Direction.up);
		}

		// Dialogue: Home
		if (timer >trigger7 && timer < trigger7+1){
			dialogue2.SetActive(true);
		}

		// Turn off second dialogue.
		if (timer > trigger8 && timer < trigger8+1) {
			dialogue2.SetActive(false);
		}

		// Walk right.
		if (timer >trigger9 && timer < trigger9+1){
			chibi.GetComponent<Rigidbody2D>().velocity = new Vector3(.5f, 0f, 0f);
			fade.BeginFade(1); // Slow fade out of scene.
			mh.setWalkingState(Direction.movingRight);
		}

		// Next Scene
		if (timer > trigger10 && timer < trigger10+1) {
			Application.LoadLevel (9); // Play Credits sequence
		}
	}
}
