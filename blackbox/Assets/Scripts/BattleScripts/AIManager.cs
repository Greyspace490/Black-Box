using UnityEngine;
using System.Collections;

// The AIManager retreieves the AI carried on the Save object, instantiates it for use in the battle, and then
// parents itself to that AI for easy access.
//

public class AIManager : MonoBehaviour {

	Save save; 
	AI ai;
	
	void Start(){ // Set up the battle field with all of the elements that are unique to this battle.
		
		save = (GameObject.FindGameObjectWithTag ("Save").GetComponent<Save> ()) as Save;

		ai = save.getAI ();

		Instantiate (ai).transform.parent = this.transform;

	}
}
