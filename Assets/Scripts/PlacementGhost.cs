using UnityEngine;
using System.Collections;

public class PlacementGhost : MonoBehaviour {

	public SpriteRenderer mySprite;
	public GameLogic myGL;
	private Camera mainCam;			//Reference to camera component of the Main Camera object


	private GameObject myType = null;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		myGL = GetComponentInParent<GameLogic> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlacementMode ();
		TrackMouse ();
		//Destroy (gameObject);
	}

	void PlacementMode() {
	//INPUT: -
	//OUTPUT: ~
	//DESCRIPTION: Checks if it's current location is a valid spot for a tile. Places tile when clicked. Probably should take the
	//current tile as input actually but we'll get there...

		bool adjacent = false;
		bool overlap = false;
		bool valid = false;
		Vector2 myPos = GetComponent<Transform> ().position;

		adjacent = Physics2D.CircleCast (myPos , 0.51f, Vector2.right, 0f);
		overlap = Physics2D.CircleCast (myPos, 0.25f, Vector2.right, 0f);

		if (Input.GetKeyDown (KeyCode.R)) {
			myType.GetComponent<Tile>().Rotate();
		}

		if (adjacent && !overlap) {
			valid = true;
			mySprite.color = Color.blue;
		} else {
			valid = false;
			mySprite.color = Color.red;
		}
		
		if (valid && Input.GetMouseButtonDown (0)) {
			Debug.Log ("Place tile at: " + myPos);
			Instantiate (myType , myPos, Quaternion.identity);
			//turnStage++;
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
}
