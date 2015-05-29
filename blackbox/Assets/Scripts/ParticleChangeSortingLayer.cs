using UnityEngine;
using System.Collections;

public class ParticleChangeSortingLayer : MonoBehaviour {

	public int layerID;
	public int sortOrder;

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = layerID;
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = sortOrder;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
