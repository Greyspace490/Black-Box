using UnityEngine;
using System.Collections;

// HintAutoHide closes the battle hints after a certain amount of time.
//
//

public class HintAutoHide : MonoBehaviour {
	
	void Update () {
		StartCoroutine (Pause());
	}

	IEnumerator Pause(){
		yield return new WaitForSeconds(10);
		gameObject.SetActive (false);
	}
}
