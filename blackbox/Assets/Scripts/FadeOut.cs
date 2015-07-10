using UnityEngine;
using System.Collections;

// FadeOut is used just to fade out a scene, as opposed to Fade which fades in and out of a scene.
//
//

public class FadeOut : MonoBehaviour {

	public Texture2D fadeTexture;   // Texture for the fade.
	public float fadeSpeed = 0.8f;  // Fade speed.

	private int drawDepth = -1000;  // Textures layer depth.
	private float alpha = 0f;     // The alpha of the texture.
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
}
