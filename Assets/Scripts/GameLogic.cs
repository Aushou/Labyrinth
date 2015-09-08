using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public int maxPlayers = 4;		//Max number of players. Can be set in Unity
	public int turnStage = 0;		//Denotes first tile placement (0), second tile (1), and movement (2). 
	public GameObject testTile;
	public GameObject tileCross;
	public GameObject tileTee;
	public GameObject tileStraight;
	public GameObject tileBend;
	public GameObject tileDead;
	public GameObject tileWall;
	public GameObject ghostTile;	//Stores the prefab for the placement ghost tile

	private int curPlayer;			//The player whose turn it currently is
	private int curTurn = 1;		//Current turn. May not be useful, but it's here
	private Camera mainCam;			//Reference to camera component of the Main Camera object
	private GameObject tempGhost;

	//DECK VARIABLES
	int numCross = 138;
	int numTee = 138;
	int numStraight = 156;
	int numBend = 96;
	int numDead = 96;
	int totalDeck = 0;

	// Use this for initialization 
	void Start () {
		mainCam = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		totalDeck = numCross + numTee + numStraight + numBend + numDead;

		if (Input.GetKeyDown (KeyCode.P)) {
			PlaceGhost (testTile);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {		//Space to skip/end turn and move to the next player
			if(curPlayer < maxPlayers){
				curPlayer++;						//Move to next player
			}
			else{
				curPlayer = 1;						//Move to the next player and turn if it's currently the last player's turn
				curTurn++;
			}
			Debug.Log("Current Player: " + curPlayer + " Current Turn: " + curTurn);
		}
	}

	void PlaceGhost(GameObject curTile) {
	//INPUT: GameObject referencing drawn tile
	//OUTPUT: Nada
	//DESCRIPTION: ALlows the player to select a grid point and place a tile down. Should display a blue ghost for valid tile
	//placement, and a red ghost for invalid.

		Vector3 mousePos = mainCam.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D;

		mousePos.z = 0;
		mousePos.x = Mathf.RoundToInt (mousePos.x);
		mousePos.y = Mathf.RoundToInt (mousePos.y);
		mousePos2D.x = mousePos.x;
		mousePos2D.y = mousePos.y;

		tempGhost = (GameObject)Instantiate (ghostTile, mousePos, Quaternion.identity);
		tempGhost.GetComponent<PlacementGhost> ().SetCamera (mainCam);

		//if (!tempGhost.GetComponent<PlacementGhost> ().TypeFlag ()) {
			tempGhost.GetComponent<PlacementGhost> ().SetTile (DrawTile ());
		//}
	}

	public GameObject DrawTile() {
	//INPUT: Hot air
	//OUTPUT: A GameObject referencing drawn tile
	//DESCRIPTION:Draws a tile from the deck of tiles, and reduces the count of that remaining card type. This way
	//tiles aren't instantiated until they're needed, and can be randomly selected and depleted like an actual deck.

		GameObject curTile;
		Debug.Log ("DRAW TILE!");

		int RNG = Random.Range (0, totalDeck);

		if (RNG < numCross) {
			curTile = tileCross;
			//Debug.Log ("Drew cross tile.");
			numCross--;
		} else if (RNG < numCross + numTee) {
			curTile = tileTee;
			//Debug.Log ("Drew T tile.");
			numCross--;
		} else if (RNG < numCross + numTee + numStraight) {
			curTile = tileStraight;
			//Debug.Log ("Drew straight tile.");
			numStraight--;
		} else if (RNG < numCross + numTee + numStraight + numBend) {
			curTile = tileBend;
			//Debug.Log ("Drew bend tile.");
			numBend--;
		} else if (RNG < numCross + numTee + numStraight + numBend + numDead) {
			curTile = tileDead;
			//Debug.Log ("Drew deadend tile.");
			numDead--;
		} else {
			curTile = null;
			//Debug.Log("RNG out of range");
		}
		
		return curTile;
	}
}
