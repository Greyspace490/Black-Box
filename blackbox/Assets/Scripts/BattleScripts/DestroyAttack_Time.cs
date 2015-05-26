using UnityEngine;
using System.Collections;

// DestroyAttack_Time destroys whatever it is attached to after a certain amount of time.
//
//

public class DestroyAttack_Time : MonoBehaviour {

	public int delay;

	public DestroyAttack_Time()
	{
		delay = 250; // Time before destruction.
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		Destroy (gameObject, (delay * Time.deltaTime));
		       
	}
}
