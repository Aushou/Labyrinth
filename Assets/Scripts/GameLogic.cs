using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	public int maxPlayers = 4;		//Max number of players. Can be set in Unity
	public int turnStage = 0;		//Denotes first tile placement (0), second tile (1), and movement (2). 
	public GameObject testTile;		//Tile just for testing
	public GameObject ghostTile;	//Stores the prefab for the placement ghost tile

	private int curPlayer;			//The player whose turn it currently is
	private int curTurn = 1;		//Current turn. May not be useful, but it's here
	//private GameObject curTile;	//Set by DrawTile function	
	private List <GameObject> tileDeck = new List<GameObject>();		//The deck of tiles
	private Camera mainCam;			//Reference to camera component of the Main Camera object
	private GameObject tempGhost;

	//DECK VARIABLES
	int numCross = 138;
	int numTee = 138;
	int numStraight = 156;
	int numBend = 96;
	int numDead = 96;

	// Use this for initialization 
	void Start () {
		mainCam = GetComponentInChildren<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

		//while (turnStage == 0 || turnStage == 1) {
			//Destroy (tempGhost);
			PlaceGhost(testTile);
		//}

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
	}

	GameObject DrawTile() {
	//INPUT: Hot air
	//OUTPUT: A GameObject referencing drawn tile
	//DESCRIPTION: Draws a tile from the deck

		GameObject curTile = null;
		
		return curTile;
	}

	void CreateDeck(){
	//INPUT: Emotion
	//OUTPUT: The infintesimal horrors of the Warp
	//DESCRIPTION: Creates the deck of tiles as per specification

	}

	void DrawTile(){
	//INPUT: Something clever
	//OUPUT: Not clever at all
	//DESCRIPTION: Draws a tile from the deck of tiles, and reduces the count of that remaining card type. This way
	//tiles aren't instantiated until they're needed, and can be randomly selected and depleted like an actual deck.

	}
}
