using UnityEngine;
using System.Collections;

// SupraEvent is the base class of all event managers, which allows all nodes to use any event manager.
//
//

public abstract class  SupraEvent : MonoBehaviour {
	
	abstract public void playEvent (int i);
}
