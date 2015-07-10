using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Save is created at the title screen and carries through every scene, keeping track of which nodes have been visited
// as well as the location of the player when they leave a scene so that they can be placed back at that location 
// later.

public class Save : MonoBehaviour {

	public Vector3 previousLocation; // The location the player is leaving from.
	public Vector3 newLocation; // The location where the player is to be placed by the MovementHandler upon the scene loading.
	public Animal playerAnimal; // The animal that the player will use whenever they are in battle.
	AI ai; // The AI that the enemy will use in battle.
	Animal enemyAnimal; // The animal the enmy will use in battle.
	List<int> nodesVisited = new List<int>(1); // A list of all the nodes that have been visited.
	int lastLevel; // The level the player was last at, used by the battle scene to know where to send the player back to.
	bool canGoLeft; // Saves the walking state of the player to allow the disallowing of them from walking during dialogue.
	bool canGoRight;
	bool canGoUp;
	bool canGoDown;
	Sprite battleBackground; // The background for the battle to be fought.
	Vector3 cameraLocation = new Vector3(0, 0, -10); // The coordinates of the camera, for use after a battle commences..

	public void setCameraLocation (Vector3 newLoc){
		cameraLocation = newLoc;
	}

	public Vector3 getCameraLocation(){
		return cameraLocation;
	}

	public void setBattleBG(Sprite bg){
		battleBackground = bg;
	}

	public Sprite getBattleBG(){
		return battleBackground;
	}

	public void setDirections(bool left, bool right, bool up, bool down){
		canGoLeft = left;
		canGoRight = right;
		canGoUp = up;
		canGoDown = down;
	}

	public bool GetLeft(){
		return canGoLeft;
	}
	public bool GetRight(){
		return canGoRight;
	}
	public bool GetUp(){
		return canGoUp;
	}
	public bool GetDown(){
		return canGoDown;
	}

	public AI getAI(){
		return ai;
	}
	
	public void setAI(AI newAI){
		ai = newAI;
	}

	public Animal getPlayerAnimal(){
		return playerAnimal;
	}

	public Animal getEnemyAnimal(){
		return enemyAnimal;
	}

	public void setPlayerAnimal(Animal animal){
		playerAnimal = animal;
	}
	
	public void setEnemyAnimal(Animal animal){
		enemyAnimal = animal;
	}

	public int getPreviousLevel(){
		return lastLevel;
	}

	public void setPreviousLevel(int level){
		lastLevel = level;
	}
	
	void Awake () {
		DontDestroyOnLoad (transform.gameObject); // Stops the object from being destroyed on scene load.
		newLocation = new Vector3 (0, 0, 0);
	}

	public Vector3 getPreviousLocation(){ 
		return previousLocation;
	}

	public void setPreviousLocation(Vector3 location){
		previousLocation = location;
	}

	public Vector3 getNewLocation(){
		return newLocation;
	}
	
	public void setNewLocation(Vector3 location){
		newLocation = location;
	}

	public void AddNode(int nodeNum){
		bool newNumber = true;

		for (int i = 0; i < nodesVisited.Count; i++) { // If the node is already in the collection, it does not add that same node again.
			if (nodesVisited [i] == nodeNum)
				newNumber = false;
		}

		if (newNumber)
			nodesVisited.Add(nodeNum);
	}

	public bool CheckNode(int nodeNum){ // Returns true or false depending on if the node has been activated before or not.
		bool visited = false;

		for (int i = 0; i < nodesVisited.Count; i++) {
			if (nodesVisited [i] == nodeNum)
				visited = true;
		}
		return visited;
	}

	public void RemoveNode(int nodeNum){ // Removes a node if it exists in the collection. Used by nodes that have repeatable events.
		for (int i = 0; i < nodesVisited.Count; i++) {
			if (nodesVisited [i] == nodeNum){
				nodesVisited.RemoveAt(i);
			}
		}
	}
}
