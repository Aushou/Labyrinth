using UnityEngine;
using System.Collections;

public class PlacementGhost : MonoBehaviour {

	public SpriteRenderer mySprite;
	public GameLogic myGL = null;
	private Camera mainCam;			//Reference to camera component of the Main Camera object


	private GameObject myType = null;
	int rotation = 0;


	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().sprite = myType.GetComponent<SpriteRenderer>().sprite;
		PlacementMode ();
		TrackMouse ();
		//Destroy (gameObject);
	}

	void PlacementMode() {
	//INPUT: -
	//OUTPUT: ~
	//DESCRIPTION: Checks if it's current location is a valid spot for a tile. Places tile when clicked. 

		bool adjacent = false;
		bool overlap = false;
		bool valid = false;
		bool[] validSides = new bool[4];
		Vector2 myPos = GetComponent<Transform> ().position;

		adjacent = Physics2D.CircleCast (myPos , 0.7f, Vector2.right, 0f);
		overlap = Physics2D.CircleCast (myPos, 0.25f, Vector2.right, 0f);

		if (Input.GetKeyDown (KeyCode.R)) {
			myType.GetComponent<Tile>().Rotate();
			rotation ++;
			GetComponent<Transform> ().rotation = Quaternion.Euler (0, 0, rotation * -90);
		}

		if (adjacent && !overlap) {
			//If it fits the initial constraints, starts checking if pathways match  up
			RaycastHit2D hit;
			//Ray2D ray = Physics2D.Raycast (myPos, Vector2.up, 0.7f);

			if (Physics2D.Raycast(myPos, Vector2.up, 0.7f)){
				hit = Physics2D.Raycast (myPos, Vector2.up, 0.7f);
				//Debug.Log (hit.transform.gameObject.GetComponent<Tile>().south);
				validSides[0] = hit.transform.gameObject.GetComponent<Tile>().GetSouth () && myType.GetComponent<Tile>().GetNorth();
			} else {
				validSides[0] = true;
			}
			if (Physics2D.Raycast (myPos, Vector2.right, 0.7f)){
				hit = Physics2D.Raycast (myPos, Vector2.right, 0.7f);
				validSides[1] = hit.transform.gameObject.GetComponent<Tile>().GetWest () && myType.GetComponent<Tile>().GetEast ();
			} else {
				validSides[1] = true;
			}
			if (Physics2D.Raycast (myPos, Vector2.down, 0.7f)){
				hit = Physics2D.Raycast (myPos, Vector2.down, 0.7f);
				validSides[2] = hit.transform.gameObject.GetComponent<Tile>().GetNorth () && myType.GetComponent<Tile>().GetNorth();
			} else {
				validSides[2] = true;
			}
			if (Physics2D.Raycast (myPos, Vector2.left, 0.7f)){
				hit = Physics2D.Raycast (myPos, Vector2.left, 0.7f);
				validSides[3] = hit.transform.gameObject.GetComponent<Tile>().GetEast() && myType.GetComponent<Tile>().GetWest();
			} else {
				validSides[3] = true;
			}

			if(validSides[1]&&validSides[2]&&validSides[3] && validSides[0]){
				valid = true;
				mySprite.color = Color.blue;
			} else{
				valid = false;
				mySprite.color = Color.red;
			}
		} else {
			valid = false;
			mySprite.color = Color.red;
		}

		if (valid && Input.GetMouseButtonDown (0)) {
			Instantiate (myType , myPos, Quaternion.Euler (0, 0, (-90 * rotation)));
			myGL.IncrementStage();
			Destroy (gameObject);
		}

		//Debug.Log ("Adjacent: " + adjacent + ", Overlap: " + overlap);
	}

	void TrackMouse(){
		Vector3 mousePos = mainCam.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos2D;
		
		mousePos.z = 0;
		mousePos.x = Mathf.RoundToInt (mousePos.x);
		mousePos.y = Mathf.RoundToInt (mousePos.y);
		mousePos2D.x = mousePos.x;
		mousePos2D.y = mousePos.y;

		GetComponent<Transform> ().position = mousePos2D;
	}

	public void SetTile(GameObject tileType){
	//INPUT: GameObject referring to a type of tile
	//OUTPUT: None, I think for now...
	//DESCRIPTION: Set's the tile type for this ghost.
		myType = tileType;
	}

	public void SetCamera(Camera myCam){
		mainCam = myCam;
	}

	public void SetMyGL(GameLogic newGL){
		Debug.Log ("Set myGL!");
		myGL = newGL;
	}
}
