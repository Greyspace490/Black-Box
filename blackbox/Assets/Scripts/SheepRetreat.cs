using UnityEngine;
using System.Collections;

// Sheep retreat moves the sheep away from the player on the overworld map as they approach.
//
//

public class SheepRetreat : MonoBehaviour {

	bool upOrDown;

	void Start () {

		if (Random.Range (0, 2) == 1)
			upOrDown = true;
		else
			upOrDown = false;

	}

	public IEnumerator OnTriggerEnter2D(Collider2D collider) 
	{
		if (upOrDown == true) {
			for(int i = 0; i < 20; i++){
				transform.localPosition = transform.localPosition + new Vector3 (0, .1f, 0);
				yield return new WaitForSeconds(.02f);
			}
		} else {
			for(int i = 0; i < 20; i++){
				transform.localPosition = transform.localPosition + new Vector3 (0, -.1f, 0);
				yield return new WaitForSeconds(.02f);
			}
		}
	}
	

}
