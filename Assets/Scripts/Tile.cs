using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public bool north;			//Booleans denoting which sides of the tile are open for passage
	public bool east;
	public bool south;
	public bool west;
	
	// Use this for initialization
	void Start () {
		north = false;
		east = false;
		south = false;
		west = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public bool GetNorth(){
		return north;
	}

	public bool GetEast(){
		return east;
	}

	public bool GetSouth(){
		return south;
	}

	public bool GetWest(){
		return west;
	}

	public void Rotate(){
	//INPUT: Existentialism
	//OUTPUT: Nihilism
	//DESCRIPTION: Rotates clockwise

		bool tempN = north;
		bool tempE = east;
		bool tempS = south;
		bool tempW = west;

		north = tempW;
		east = tempN;
		south = tempE;
		west = tempS;

		GetComponent<Transform> ().Rotate (0, 0, 90);

		Debug.Log ("Rotating...");
	}
}
