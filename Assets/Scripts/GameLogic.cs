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

	// Use this for initialization 
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//while (turnStage == 0 || turnStage == 1) {
			PlaceTile(testTile);
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

	void PlaceTile(GameObject curTile) {
	//INPUT: GameObject referencing drawn tile
	//OUTPUT: Nada
	//DESCRIPTION: ALlows the player to select a grid point and place a tile down. Should display a blue ghost for valid tile
	//placement, and a red ghost for invalid. Should check all adjacent tiles to ensure it will match up with the hallways

		GameObject tempGhost = ghostTile;
		Vector2 mousePos = Input.mousePosition;  //NOTE: Needs to convert to worldPos...

		mousePos.x = Mathf.RoundToInt (mousePos.x);
		mousePos.y = Mathf.RoundToInt (mousePos.y);
		Debug.Log (mousePos);

		if (Input.GetKeyDown (KeyCode.S)){
			turnStage++;
		}

	}

	GameObject DrawTile() {
	//INPUT: Hot air
	//OUTPUT: A GameObject referencing drawn tile
	//DESCRIPTION: Draws a tile from the deck

		GameObject curTile = null;
		
		return curTile;
	}

	void ShuffleDeck() {
	//INPUT: Nothing
	//OUTPUT: Dreams
	//DESCRIPTION: Initialises and shuffles the deck of tiles



	}
}
