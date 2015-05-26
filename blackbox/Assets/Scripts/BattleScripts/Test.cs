using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void whatevs(){

//		string[] attackNames = new string[3] {"Attack", "Herd Sight", "Breed"};
		//Player player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
		UIHandler uiHandler = GameObject.FindWithTag ("UIHandler").GetComponent<UIHandler> ();
		uiHandler.toggleInteractableButton (2, true);

		//Timer timer = GameObject.FindWithTag ("Timer").GetComponent<Timer> ();
		Debug.Log (true);
		//timer.toggleTimer (2, true);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
