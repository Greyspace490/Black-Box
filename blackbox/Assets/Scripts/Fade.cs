using UnityEngine;
using System.Collections;

// Fade is used to fade in (or out) from a scene. An image can be faded into our out of, or a black texture can be used
// to fade to black.  Fade speed can be set to determine how fast a scene fades.
//

public class Fade : MonoBehaviour {

	public Texture2D fadeTexture;   // Texture for the fade.
	public float fadeSpeed = 0.8f;  // Fade speed.

	private int drawDepth = -1000;  // Textures layer depth.
	private float alpha = 1.0f;     // The alpha of the texture.
	private int fadeDirection = -1; // -1 = fade in, 1 = fade out.


	void OnGUI() {

		// Force the number between 0 and 1 because GUI.color uses alphas between 1 and 0.
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Colors remain the same, alpha is set.
		GUI.depth = drawDepth; // Set depth of the fade so that it is drawn last.
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture); // Fit texture to screen
	}

	public float BeginFade (int direction){
		fadeDirection = direction;
		return (fadeSpeed); // Returns fade speed to allow for timing.
	}

	public float BeginFade (int direction, bool useSecondFadeColor){
		fadeDirection = direction;
		return (fadeSpeed); // Returns fade speed to allow for timing.
	}

	void OnLevelWasLoaded (){
		BeginFade (-1); // Call fade in
	}
}
