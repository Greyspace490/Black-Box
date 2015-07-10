using UnityEngine;
using System.Collections;

// Comic plays the comic.
//
//

public class Comic : MonoBehaviour {

	public GameObject page1;
	public GameObject page2;
	public GameObject page3;
	public GameObject page4;
	public GameObject page5;
	public GameObject page6;

	bool t2 = false;
	bool t3 = false;
	bool t4 = false;
	bool t5 = false;
	bool t6 = false;

	bool turnOffInput2 = false;
	bool turnOffInput3 = false;
	bool turnOffInput4 = false;
	bool turnOffInput5 = false;
	bool turnOffInput6 = false;
	
	bool go = false;
	
	void Update () {

		StartCoroutine (Pause (1));
		page1.SetActive (true);

		
		if (Input.anyKey && go) {
			page2.SetActive (true);
			if (!turnOffInput2){
				Input.ResetInputAxes();
				turnOffInput2 = true;
			}
			t2 = true;
		}
		
		if (Input.anyKey && t2) {
			page3.SetActive (true);
			if (!turnOffInput3){
				Input.ResetInputAxes();
				turnOffInput3 = true;
			}
			t3 = true;
		}
		if (Input.anyKey && t3) {
			page4.SetActive (true);
			if (!turnOffInput4){
				Input.ResetInputAxes();
				turnOffInput4 = true;
			}
			t4 = true;
		}
		if (Input.anyKey && t4) {
			page5.SetActive (true);
			if (!turnOffInput5){
				Input.ResetInputAxes();
				turnOffInput5 = true;
			}
			t5 = true;
		}
		if (Input.anyKey && t5) {
			page6.SetActive (true);
			if (!turnOffInput6){
				Input.ResetInputAxes();
				turnOffInput6 = true;
			}
			t6 = true;
		}
		
		if (Input.anyKey && t6) {
			StartCoroutine(Proceed());
		}
	}
	
	IEnumerator Proceed(){ // Fades to black.
		float fadeTime = GetComponent<Fade>().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(4);
	}
	
	IEnumerator Pause(int x){ // Pauses for x amount of seconds.
		yield return new WaitForSeconds(x);
		go = true;
	}
	
	
}