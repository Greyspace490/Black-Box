using UnityEngine;
using System.Collections;

// TimeStormCluster keeps a timer.  At each point, a portion of the attack is initated, ending with
// the object destroying itself.
//

public class TimeStormCluster: MonoBehaviour {

	public GameObject blackHole; // BlackHole that grows at the end of the attack.
	float time = 0f;

	// Update is called once per frame
	void Update () {
		time= time + (1f * Time.deltaTime); // Timer

		if (time > 4.5f) // Start to move nodes toward each other.
			transform.localScale -= new Vector3(.01f, .01f, .01f);

		if (time > 5.5f) // Start to grow blackHole to eclipse the entire screen.
			blackHole.transform.localScale += new Vector3(40f, 40f, 0f);

		if (time > 6.7){ // Destroy the object.
			Destroy(gameObject);
		}


	}
}
