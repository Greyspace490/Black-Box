using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public DialogueHandler dh;

	public void playEvent(int i){
		if (i == 1) {
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "What?  Where... where am I? It's like the Lincoln Park zoo but... everything is destroyed.  And... old."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "And who were those soldiers? Why did they attack me? Was it for this? [holds up amulet]", "???", Portrait.Quinn, "Hello World."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "!!!"));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Did... did you just say something??", "???", Portrait.Quinn, "A salutation."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "Am I talking to a parking meter right now?", "???", Portrait.Quinn, "Affirmative."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "And is this not the weirdest thing ever?", "???", Portrait.Quinn, "Strangeness is relative. But if you value continued existence, my recommendation is swift departure."));
			StartCoroutine(dh.showMessage("Kayla", Portrait.Kayla, "You want us to leave?", "???", Portrait.Quinn, "Yes. Now."));
		}
	}

}
