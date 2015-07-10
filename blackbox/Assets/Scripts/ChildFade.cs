using UnityEngine;
using System.Collections;

// ChildFade forces the child of an object to maintain the transparency of its parent.  It is used to fade the shadow
// of an enemy that dies in battle and is faded out of battle.
//

public class ChildFade : MonoBehaviour {
	
	void Update () {
		GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
	}
}
