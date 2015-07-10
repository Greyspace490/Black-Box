using UnityEngine;
using System.Collections;

// CameraMovement moves the camera when the player reaches the edge of the Overworld map.
//
//

public class CameraMovement : MonoBehaviour {

	Chibi chibi;
	Vector3 transferPoint; // The point at which the chibi needs to reach before the camera moves.
	Vector3 newCameraPoint; // The point to move the canmera.
	bool moveCamera;
	
	void Start () {
		chibi = GameObject.FindGameObjectWithTag("Chibi").GetComponent<Chibi>();
		transferPoint = new Vector3 (6.37f, 4.49f, 0);	
		moveCamera = false;
		newCameraPoint = new Vector3 (19.93f, 0, -10);
		Save save = (GameObject.FindGameObjectWithTag("Save").GetComponent<Save>()) as Save;
		transform.position = save.getCameraLocation();

	}

	void Update () {
		// If the player walks to edge of the screen, allow movement of camera.
		if (Vector3.Distance (chibi.transform.localPosition, transferPoint)< 1.0f) {
			moveCamera = true;
		}

		// Movement of camera.
		if ((moveCamera == true) && !(gameObject.transform.localPosition == newCameraPoint)) {
			transform.position = Vector3.MoveTowards(transform.position, newCameraPoint, .05f);
		}
	}
}
