using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// MoveText scrolls text upward. It is used to "float" damage upward after it has been received by either the player
// or enemy, or for use with the credits sequence.
//

public class MoveText : MonoBehaviour {

	public Text scrollText; // Text to be scrolled.
	public float speed = .1f; // Speed to move the text upwards.
	Vector3 originalPosition; // Place where text begins, in case text needs to be reset to that position.

	void Awake(){
		originalPosition = scrollText.rectTransform.localPosition;
	}

	void OnGUI(){
		if (scrollText.IsActive ()) // When the text is showing, move it upward.
			scrollText.rectTransform.localPosition = scrollText.rectTransform.localPosition + new Vector3 (0, speed, 0);
		else // If the text has been hidden, move it back to its original position.
			scrollText.rectTransform.localPosition = originalPosition;
	}
}
