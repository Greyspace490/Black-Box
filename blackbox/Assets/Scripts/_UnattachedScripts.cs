using UnityEngine;
using System.Collections;

// List of enums and other scripts that are available in all scripts.
//
//

public enum Direction{ // Direction names for use with chibi walking in overworld. Moving directions indicate that the chibi is actually moving in that direction as well.
	left, right, up, down, movingLeft, movingRight, movingUp, movingDown
}

public static class Speed{ // Constants for use with speed multipliers for animal attacks.
	public const float vvvslow = .10f;
	public const float vvslow = .25f;
	public const float vslow = .50f;
	public const float slow = .75f;
	public const float normal = 1f;
	public const float fast = 1.25f;
	public const float vfast = 1.5f;
	public const float vvfast = 2f;
	public const float vvvfast = 3f;
	public const float none = 0;
}

public static class Portrait{ // Constants for use of posting portraits with the DialogueHandler.
	public const string Calvert = @"Portraits/PortraitCalvert";
	public const string Kayla = @"Portraits/PortraitKayla";
	public const string Quinn = @"Portraits/PortraitQuinn";
}

public enum element{ // Elements for use with attack resistance.
	electricity, water, fire, ice, stone, nothing
}

public enum effectiveness{ // Rating of how effective an attack is.
	strong, regular, weak
}

public struct damageResults {
	private int damageValue;
	private effectiveness effectivenessValue;

	public damageResults(int damage, effectiveness effectiveness){
		damageValue = damage;
		effectivenessValue = effectiveness;
	}

	public int damage {
		get {
			return damageValue;
		}
		set {
			damageValue = value;
		}
	}
	public effectiveness effectiveness{
		get{
			return effectivenessValue;
		}
		set{
			effectivenessValue = value;
		}
	}
}